using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor
{
    public class DoctorProfileModel : PageModel
    {
        private readonly IUserService userService;

        public DoctorProfileModel(IUserService _userService)
        {
            userService = _userService;
        }

        [BindProperty]
        public User user { get; set; } = default!;

        public void OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }
        }
    }
}
