using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicServices.Interface;

namespace PetClinic.Pages.ProfilePages
{
    public class DoctorProfileModel : PageModel
    {
        private readonly IUserService userService;

        public void OnGet()
        {

        }
    }
}
