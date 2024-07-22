using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageCustomer
{
    public class AdminViewCustomerListModel : PageModel
    {
		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }

		[BindProperty]
		public List<User> Customers { get; set; }

		private readonly IUserService userService;

		public AdminViewCustomerListModel(IUserService _userService)
		{
			userService = _userService;
		}
		public void OnGet()
        {
			Customers = userService.GetAllUsers();
		}


    }
}
