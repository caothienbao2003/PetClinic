using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinic.Custom_Model;
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
        [BindProperty]
        public ScheduleBlockModel BlockModel { get; set; }

        public void OnGet(int doctorid)
        {
            DoctorId = doctorid;

            ShiftList = shiftService.GetAllDoctorShifts();
            SelectedDate = DateTime.Now;
            LoadMondayAndSunday();
            ScheduleList = scheduleService.GetByEmployeeIdBetweenDate(DoctorId, MondayDate, SundayDate);
        }

        public void OnPostChangeWeek(int offset)
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            DateTime tempDate = SelectedDate.AddDays(6 * offset);
            SelectedDate = tempDate;
            LoadMondayAndSunday();
            ScheduleList = scheduleService.GetByEmployeeIdBetweenDate(DoctorId, MondayDate, SundayDate);
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
