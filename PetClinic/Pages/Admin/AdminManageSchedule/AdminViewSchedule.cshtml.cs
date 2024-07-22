using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageSchedule
{
    public class AdminViewScheduleModel : PageModel
    {
		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }

		private readonly IScheduleService scheduleService;
		public AdminViewScheduleModel(IScheduleService scheduleService)
		{
			this.scheduleService = scheduleService;
		}

		[BindProperty]
		public UserRole UserRole { get; set; }

		public void OnGet()
		{

		}
	}
}
