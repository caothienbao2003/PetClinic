using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;
using System.Net;
using System.Security.Claims;

namespace PetClinic.Pages.Authentication
{
    public class CustomerRegisterModel : PageModel
    {
        [BindProperty]
        public string userName { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string phoneNumber { get; set; }
        [BindProperty]
        public string address { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string gender { get; set; }

        private readonly IUserService _userService;
		private readonly ILogger<CustomerRegisterModel> _logger;
		public CustomerRegisterModel(IUserService userService, ILogger<CustomerRegisterModel> logger)
        {
            _userService = userService;
			_logger = logger;
		}

        public void OnGet()
        {
        }

        public void OnPostAsync()
        {

        }

        public void OnPostRegister()
        {
            if (!ModelState.IsValid)
            {
				return;
            }

			var newUser = new User
            {
                Username = userName,
                Password = password,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email,
                Gender = gender,
                Role = 0 //0 is the role for a customer
            };

            _userService.AddUser(newUser); // Assuming AddUser is a method in IUserService to add a user

            RedirectToPage("/Authentication/Login");
        }

		// Handle external login
		public IActionResult OnGetExternalLogin(string provider)
		{
			var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback");
			var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
			return new ChallengeResult(provider, properties);
		}

		// Handle external login callback
		public async Task<IActionResult> OnGetExternalLoginCallback()
		{
			var authResult = await HttpContext.AuthenticateAsync();
			if (!authResult.Succeeded)
			{
				_logger.LogWarning("External authentication failed");
				return RedirectToPage("/Error");
			}

			string email = authResult.Principal.FindFirstValue(ClaimTypes.Email);
			_logger.LogInformation("OAuth login with email: {email}", email);

			return RedirectToPage("/Privacy");
		}
	}
}
