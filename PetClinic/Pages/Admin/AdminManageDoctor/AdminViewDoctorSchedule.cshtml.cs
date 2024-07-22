using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageDoctor
{
    public class AdminViewDoctorScheduleModel : PageModel
    {
        private readonly IScheduleService scheduleService;
        private readonly IShiftService shiftService;
        public AdminViewDoctorScheduleModel(IScheduleService scheduleService, IShiftService shiftService)
        {
            this.scheduleService = scheduleService;
            this.shiftService = shiftService;
        }

        [BindProperty]
        public DateTime MondayDate { get; set; }
        [BindProperty]
        public DateTime SundayDate { get; set; }
        [BindProperty]
        public DateTime SelectedDate { get; set; }
        [BindProperty]
        public List<Shift> ShiftList { get; set; }

        [BindProperty]
        public List<Schedule> ScheduleList { get; set; }
        [BindProperty]
        public int DoctorId { get; set; }

        public void OnGet(int doctorid)
        {
            DoctorId = doctorid;

            Console.WriteLine("Doctor id: " + doctorid);

            ShiftList = shiftService.GetAllDoctorShifts();
            SelectedDate = DateTime.Now;
            LoadMondayAndSunday();
        }

        public void OnPostChangeWeek(int offset)
        {
            Console.WriteLine("Doctor id: " + DoctorId);

            ShiftList = shiftService.GetAllDoctorShifts();
            SelectedDate = SelectedDate.AddDays(6 * offset);
            LoadMondayAndSunday();

            Console.WriteLine(SelectedDate);

            ScheduleList = scheduleService.GetByEmployeeIdBetweenDate(DoctorId, MondayDate, SundayDate);

            Console.WriteLine(ScheduleList.Count);


        }

        public DateTime GetMonday(DateTime selectedDate)
        {
            int offset = (int)selectedDate.DayOfWeek - (int)DayOfWeek.Monday;
            if (offset < 0)
            {
                offset += 7;
            }
            return selectedDate.AddDays(-offset).Date;
        }

        private void LoadMondayAndSunday()
        {
            MondayDate = GetMonday(SelectedDate);
            SundayDate = MondayDate.AddDays(6);
        }

        private void LoadSchedule()
        {
            foreach(var shift in ShiftList)
            {
                
            }
        }
    }
}
