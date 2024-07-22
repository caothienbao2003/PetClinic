using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.ScheduleManagement
{
    public class ViewScheduleModel : PageModel
    {
        private readonly IScheduleService scheduleService;
        private readonly IShiftService shiftService;
        public ViewScheduleModel(IScheduleService scheduleService, IShiftService shiftService)
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

        public void OnGet()
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            SelectedDate = DateTime.Now;
            LoadMondayAndSunday();
        }

        public void OnPostChangeWeek(int offset)
        {
            string userIdString = HttpContext.Session.GetString("UserId");

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);

                ShiftList = shiftService.GetAllDoctorShifts();
                SelectedDate = SelectedDate.AddDays(6 * offset);

                ScheduleList = scheduleService.GetByEmployeeIdBetweenDate(userId, MondayDate, SundayDate);

                Console.WriteLine(ScheduleList.Count);

                LoadMondayAndSunday();
            }
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
    }
}
