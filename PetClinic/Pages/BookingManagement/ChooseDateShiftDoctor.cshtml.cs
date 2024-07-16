using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;

namespace PetClinic.Pages.BookingManagement
{
    public class ChooseDateShiftDoctorModel : PageModel
    {
        private readonly IShiftService shiftService;
        private readonly IDoctorService doctorService;
        private readonly IScheduleService scheduleService;

        public ChooseDateShiftDoctorModel(IShiftService _shiftService, IDoctorService _doctorService, IScheduleService _scheduleService)
        {
            shiftService = _shiftService;
            doctorService = _doctorService;
            scheduleService = _scheduleService;
        }

        [BindProperty]
        public DateTime CurrentDateOnCalendar { get; set; }

        [BindProperty]
        public int SelectedShiftId { get; set; }

        [BindProperty]
        public int SelectedDoctorId { get; set; }

        public List<Shift> ShiftList { get; set; }

        public List<User> DoctorList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedPetId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Month { get; set; }

        [BindProperty]
        public DateTime? SelectedDate { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("SelectedPetId"))
            {
                SelectedPetId = (int)TempData["SelectedPetId"];
                TempData.Keep("SelectedPetId");
            }

            if (Year.HasValue && Month.HasValue)
            {
                CurrentDateOnCalendar = new DateTime(Year.Value, Month.Value, 1);
            }
            else
            {
                CurrentDateOnCalendar = DateTime.Today.AddDays(1); // Default to tomorrow if no date is selected
            }

            LoadData();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Request.Form.ContainsKey("SelectedDate"))
            {
                CurrentDateOnCalendar = DateTime.Parse(Request.Form["SelectedDate"]);
                LoadData(); // Load shifts and doctors based on the selected date
                return Page();
            }

            // Handle form submission logic here
            TempData["SelectedDate"] = CurrentDateOnCalendar;
            TempData["SelectedPetId"] = SelectedPetId;
            TempData["SelectedShiftId"] = SelectedShiftId;
            TempData["SelectedDoctorId"] = SelectedDoctorId;

            return RedirectToPage("/BookingManagement/ChooseDateAndShift", new { SelectedPetId, CurrentDateOnCalendar, SelectedShiftId, SelectedDoctorId });
        }

        private void LoadData()
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            DoctorList = doctorService.GetAllDoctors();
        }

        public IActionResult OnGetChooseDateShiftDoctor(int year, int month, int selectedPetId)
        {
            CurrentDateOnCalendar = new DateTime(year, month, 1);
            SelectedPetId = selectedPetId;
            LoadData();
            return Partial("_CalendarPartial", this); // _CalendarPartial is a partial view containing the calendar HTML
        }
    }
}
