using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using PetClinic.Custom_Model;
using PetClinic.Model;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PetClinic.Pages.BookingManagement
{
    public class ChooseDateShiftDoctorModel : PageModel
    {
        private readonly IShiftService shiftService;
        private readonly IDoctorService doctorService;
        private readonly IScheduleService scheduleService;
        private readonly IBookingService bookingService;

        public ChooseDateShiftDoctorModel(IShiftService _shiftService, IDoctorService _doctorService, IScheduleService _scheduleService, IBookingService _bookingService)
        {
            shiftService = _shiftService;
            doctorService = _doctorService;
            scheduleService = _scheduleService;
            bookingService = _bookingService;
        }

        [BindProperty]
        public string CurrentMonthYearDisplay
        {
            get
            {
                return new DateTime(CurrentYear, CurrentMonth, 1, 0, 0, 0, DateTimeKind.Local).ToString("MMMM yyyy");
            }
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentMonth { get; set; }

        [BindProperty]
        public List<BookingCalendarCellModel> CalendarCellList { get; set; }

        [BindProperty]
        public List<BookingShiftSelectionModel> ShiftSelectionList { get; set; }
        [BindProperty]
        public List<BookingDoctorSelectionModel> DoctorSelectionList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedPetId { get; set; }
        [BindProperty]
        public DateTime? SelectedDate { get; set; }

        [BindProperty]
        public int SelectedShiftId { get; set; }

        [BindProperty]
        public int? SelectedDoctorId { get; set; }


        public void OnGet()
        {
            if (TempData.ContainsKey("SelectedPetId"))
            {
                SelectedPetId = (int)TempData["SelectedPetId"];
                TempData.Keep("SelectedPetId");
            }

            Console.WriteLine("Pet id: " + SelectedPetId);

            InitalizeCalendar();
        }

        public void InitalizeCalendar()
        {
            DateTime today = DateTime.Now;

            CurrentMonth = today.Month;
            CurrentYear = today.Year;

            Console.WriteLine("Init calendar Pet id: " + SelectedPetId);

            LoadCalendar();
        }

        public void OnPostChangeMonth(int offset)
        {
            CurrentMonth += offset;
            if (CurrentMonth < 1)
            {
                CurrentYear--;
                CurrentMonth = 12;
            }
            else if (CurrentMonth > 12)
            {
                CurrentYear++;
                CurrentMonth = 1;
            }

            Console.WriteLine("Change month Pet id: " + SelectedPetId);


            LoadCalendar();
            LoadShift();
        }

        public void LoadCalendar()
        {
            CalendarCellList = new List<BookingCalendarCellModel>();

            DateTime firstDateOfMonth = new DateTime(CurrentYear, CurrentMonth, 1);
            DateTime lastDateOfMonth = firstDateOfMonth.AddMonths(1).AddDays(-1);
            int startDate = (int)firstDateOfMonth.DayOfWeek;
            DateTime currentDate = firstDateOfMonth;
            if (startDate != 0)
            {
                currentDate = currentDate.AddDays(-startDate);
            }

            while (currentDate <= lastDateOfMonth || currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                Schedule checkSchedule = ScheduleDAO.Instance.GetOneScheduleByDate(currentDate);
                bool isAvailableDate = currentDate >= DateTime.Today.AddDays(1) && currentDate.Month == CurrentMonth && checkSchedule != null;
                var isSelectedDate = currentDate.Date == SelectedDate?.Date;

                BookingCalendarCellModel newCell = new BookingCalendarCellModel
                {
                    Date = currentDate,
                    IsAvailable = isAvailableDate,
                    IsSelected = isSelectedDate
                };

                CalendarCellList.Add(newCell);
                currentDate = currentDate.AddDays(1);
            }

            Console.WriteLine("Load calendar Pet id: " + SelectedPetId);
        }

        public void OnPostChooseDate(DateTime date)
        {
            CurrentMonth = date.Month;
            CurrentYear = date.Year;

            SelectedDate = date;
            LoadCalendar();
            LoadShift();
            Console.WriteLine("ChooseDate Pet id: " + SelectedPetId);

        }

        public void LoadShift()
        {
            DateTime selectedDate = SelectedDate == null ? DateTime.Today.AddDays(1) : SelectedDate.Value;

            List<Shift> shiftList = shiftService.GetAllDoctorShifts();
            ShiftSelectionList = new List<BookingShiftSelectionModel>();

            foreach (Shift shift in shiftList)
            {
                bool isAvailable = false;

                int capacity = 0;
                int noOfOccupation = 0;
                List<Schedule> schedule = scheduleService.GetAvailableScheduleList(selectedDate, shift.ShiftId);

                foreach (Schedule s in schedule)
                {
                    User doctor = doctorService.GetDoctorById((int)s.EmployeeId);
                    capacity += (int)doctor.DoctorCapacity;
                    noOfOccupation += (int)s.NoOfOccupation;
                }


                isAvailable = !schedule.IsNullOrEmpty() && noOfOccupation < capacity;

                BookingShiftSelectionModel newShift = new BookingShiftSelectionModel
                {
                    ShiftId = shift.ShiftId,
                    ShiftDisplay = shift.StartTime?.ToString() + " - " + shift.EndTime?.ToString(),
                    IsAvailable = isAvailable,
                    IsSelected = SelectedShiftId == shift.ShiftId,
                    OccupationDisplay = noOfOccupation.ToString() + " / " + capacity.ToString() + (noOfOccupation >= capacity ? " Full" : "")
                };

                ShiftSelectionList.Add(newShift);
            }

            Console.WriteLine("Load shift Pet id: " + SelectedPetId);

        }

        public void OnPostChooseShift(int shiftId)
        {
            SelectedShiftId = shiftId;

            LoadShift();
            LoadDoctor();
            LoadCalendar();

            Console.WriteLine("Choose Shift Pet id: " + SelectedPetId);

        }

        public void LoadDoctor()
        {
            DateTime selectedDate = SelectedDate == null ? DateTime.Today.AddDays(1) : SelectedDate.Value;

            List<User> doctorList = doctorService.GetAllDoctors();

            foreach (User doctor in doctorList)
            {
                bool isAvailable = false;

                List<Schedule> scheduleList = scheduleService.GetAvailableScheduleList(selectedDate, SelectedShiftId, doctor.UserId);

                if (!scheduleList.IsNullOrEmpty())
                {
                    isAvailable = true;
                }

                BookingDoctorSelectionModel newDoctorModel = new BookingDoctorSelectionModel()
                {
                    DoctorId = doctor.UserId,
                    DoctorName = doctor.FirstName + " " + doctor.LastName,
                    IsAvailable = isAvailable,
                    IsSelected = SelectedDoctorId == doctor.UserId
                };

                DoctorSelectionList.Add(newDoctorModel);
            }
            Console.WriteLine("Load doctor Pet id: " + SelectedPetId);

        }

        public void OnPostChooseDoctor(int doctorId)
        {
            SelectedDoctorId = doctorId;

            LoadShift();
            LoadDoctor();
            LoadCalendar();
            Console.WriteLine("Choose doctor Pet id: " + SelectedPetId);

        }

        public void OnPostNext()
        {
            Console.WriteLine("Next Pet id: " + SelectedPetId);
            Console.WriteLine("SelectedDate: " + SelectedDate);
            Console.WriteLine("SelectedShiftId: " + SelectedShiftId);
            Console.WriteLine("SelectedDoctorId: " + SelectedDoctorId);

            TempData["SelectedPetId"] = SelectedPetId;
            TempData["SelectedDate"] = SelectedDate;
            TempData["SelectedShiftId"] = SelectedShiftId;

            List<Schedule> scheduleList = null;

            if (SelectedDoctorId == null)
            {
                if (SelectedDate != null)
                {
                    scheduleList = scheduleService.GetAvailableScheduleList((DateTime)SelectedDate, SelectedShiftId).ToList();
                }
            }
            else
            {
                if (SelectedDate != null)
                {
                    scheduleList = scheduleService.GetAvailableScheduleList((DateTime)SelectedDate, SelectedShiftId, (int)SelectedDoctorId).ToList();
                }
            }

            if (scheduleList != null)
            {

                foreach (Schedule s in scheduleList)
                {
                    //Booking checkExistedBooking = bookingService.GetBooking


            }
            }

            if (SelectedDoctorId != null)
            {
                TempData["SelectedDoctorId"] = SelectedDoctorId;
            }

            Response.Redirect("/Customer/BookingManagement/BookingConfirmation");
        }
    }
}

