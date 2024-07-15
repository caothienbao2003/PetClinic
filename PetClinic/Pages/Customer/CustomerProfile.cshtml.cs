using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer
{
    public class CustomerProfileModel : PageModel
    {
        private readonly IUserService userService;

        public CustomerProfileModel(IUserService _userService)
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

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var existingUser = userService.GetUserById(user.UserId);
                if (existingUser != null)
                {
                    existingUser.Image = user.Image;
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.Address = user.Address;
                    existingUser.Password = user.Password;
                    existingUser.Gender = user.Gender;

                    userService.UpdateUser(existingUser);
                }
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!UserExists(user.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CustomerProfile");
        }

        private bool UserExists(int userId)
        {
            return userService.GetUserById(userId) != null;
        }
    }
}
