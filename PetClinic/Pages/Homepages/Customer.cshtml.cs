using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Homepages
{
    public class CustomerModel : PageModel
    {
        private readonly IUserService userService;
        public void OnGet()
        {
        }
    }
}
