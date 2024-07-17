using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                userService.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./DoctorProfile");
        }

        private bool UserExists(int userId)
        {
            return userService.GetUserById(userId) != null;
        }
    }
}