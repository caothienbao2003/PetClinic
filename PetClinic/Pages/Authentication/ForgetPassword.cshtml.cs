using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicServices.Interface;
using System.Threading.Tasks;

namespace PetClinic.Pages.Authentication
{
    public class ForgetPasswordModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }

        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public ForgetPasswordModel(IUserService _userService, IEmailService _emailService)
        {
            userService = _userService;
            emailService = _emailService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = userService.GetUserByEmail(email);
            if (user != null)
            {
                // Generate password reset token (implementation depends on your user service)
                var token = userService.GeneratePasswordResetToken(user);
                var resetLink = Url.Page("/Authentication/ResetPassword", null, new { token = token, email = email }, Request.Scheme);

                // Send the email
                await emailService.SendEmailAsync(email, "Password Reset", $"Please reset your password by clicking <a href='{resetLink}'>here</a>.");

                // Optionally show a confirmation message
                return RedirectToPage("ForgetPasswordConfirmation");
            }

            // Optionally show an error message
            ModelState.AddModelError(string.Empty, "Email not found");
            return Page();
        }
    }
}
