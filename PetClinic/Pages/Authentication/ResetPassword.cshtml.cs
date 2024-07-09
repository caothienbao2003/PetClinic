using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicServices.Interface;
using System.Threading.Tasks;

namespace PetClinic.Pages.Authentication
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public string NewPassword { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

        private readonly IUserService userService;

        public ResetPasswordModel(IUserService _userService)
        {
            userService = _userService;
        }

        public void OnGet(string token, string email)
        {
            Token = token;
            Email = email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match");
                return Page();
            }

            var result = await userService.ResetPasswordAsync(Email, Token, NewPassword);
            if (result)
            {
                return RedirectToPage("Login");
            }

            ModelState.AddModelError(string.Empty, "Invalid token or email");
            return Page();
        }
    }
}
