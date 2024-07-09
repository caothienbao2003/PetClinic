using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices.Interface;
using System.Net;
using System.Security.Claims;

namespace PetClinic.Pages.Authentication
{
    public class CustomerRegisterModel : PageModel
    {
        [BindProperty]
        public string firstName { get; set; }
		[BindProperty]
		public string lastName { get; set; }
		[BindProperty]
		public string socialNumber { get; set; }
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
		public CustomerRegisterModel(IUserService userService)
        {
            _userService = userService;
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
                FirstName = firstName,
				LastName = lastName,
				SocialNumber = socialNumber,
                Password = DAOUtilities.Instance.HashPassword(password),
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email,
                Gender = gender,
                Role = 0 //0 is the role for a customer
            };

            _userService.AddUser(newUser);

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
				return RedirectToPage("/Error");
			}

			string email = authResult.Principal.FindFirstValue(ClaimTypes.Email);

			return RedirectToPage("/Privacy");
		}
	}
}
