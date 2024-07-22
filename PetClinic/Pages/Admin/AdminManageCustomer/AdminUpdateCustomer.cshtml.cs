using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageCustomer
{
    public class AdminUpdateCustomerModel : PageModel
    {
        [BindProperty]
        public decimal revenue { get; set; }
        [BindProperty]
        public int totalCustomers { get; set; }
        [BindProperty]
        public int totalBookings { get; set; }

        [BindProperty]
        public int updateActiveStatus { get; set; }
        [BindProperty]
        public int updateCustomerId { get; set; }


        private readonly IUserService userService; 

        public User existingCustomer { get; set; }

        public AdminUpdateCustomerModel(IUserService _userService)
        {
            userService = _userService;
        }

        public void OnGet(int customerId)
        {
            existingCustomer = userService.GetUserById(customerId);
            if (existingCustomer != null)
            {
                updateActiveStatus = (int)existingCustomer.ActiveStatus;
            }
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                existingCustomer.ActiveStatus = updateActiveStatus;
                userService.UpdateUser(existingCustomer);
                return RedirectToPage("/Admin/AdminManageCustomer/AdminViewCustomerList");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating customer active status.");
                return Page();
            }
        }
    }
}
