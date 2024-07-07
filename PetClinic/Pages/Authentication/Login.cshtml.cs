using MessagePack;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetClinic.Pages.Authentication
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public string email { get; set; }
		[BindProperty]
		public string password { get; set; }

		private readonly IUserService userService;
		private readonly ILogger<LoginModel> _logger;

		public LoginModel(IUserService _userService, ILogger<LoginModel> logger)
		{
			userService = _userService;
			_logger = logger;
		}


		public void OnPostLogin()
		{
			_logger.LogInformation("Login attempt with email: {email}", email);

			var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
			var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

			if (email == adminEmail && password == adminPassword)
			{
				Response.Redirect("/UserManagement/Index");
			}

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				_logger.LogWarning("Email or Password is empty");
				Response.Redirect("/Login");
			}

			User user;
			user = userService.GetUser(email, password);

			if (user == null)
			{
				_logger.LogWarning("Invalid email or password for email: {email}", email);
				Response.Redirect("/Login");
			}

			HttpContext.Session.SetString("UserId", user.UserId.ToString());
			HttpContext.Session.SetString("Role", user.Role.ToString());


			if (user.Role == 0)
			{
				Response.Redirect("/Privacy");
			}
			else if (user.Role == 1)
			{
				Response.Redirect("/BookingManagement/Index");
			}
			else if (user.Role == 2)
			{
				Response.Redirect("/PetManagement/Index");
			}
			else
			{
				Response.Redirect("/Error");
			}
		}

		/*
		public async Task<IActionResult> OnGetAsync()
		{
			var authResult = await HttpContext.AuthenticateAsync();
			if (!authResult.Succeeded)
			{
				_logger.LogWarning("Authentication failed");
				return RedirectToPage("/Error");
			}

			string email = authResult.Principal.FindFirstValue(ClaimTypes.Email);
			_logger.LogInformation("OAuth login with email: {email}", email);


			return Redirect("/Privacy");
		}

		public IActionResult OnGetAccessDenied()
		{
			return RedirectToPage("/Error");
		}
		*/
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

			// Additional logic to sign in the user with the local application.
			// ...

			return Redirect("/Privacy");
		}

	}
}
