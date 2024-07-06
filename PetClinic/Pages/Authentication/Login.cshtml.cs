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

		
		public IActionResult OnPostLogin()
		{
			_logger.LogInformation("Login attempt with email: {email}", email);

			var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
			var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

			if (email == adminEmail && password == adminPassword)
			{
				return Redirect("/UserManagement/Index");
			}

			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				_logger.LogWarning("Email or Password is empty");
				return Page();
			}

			User user;
			try
			{
				user = userService.GetUser(email, password);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error getting user from userService");
				return RedirectToPage("/Error");
			}

			if (user == null)
			{
				_logger.LogWarning("Invalid email or password for email: {email}", email);
				return Page();
			}

			HttpContext.Session.SetString("UserId", user.UserId.ToString());
			HttpContext.Session.SetString("Role", user.Role.ToString());

			switch (user.Role)
			{
				case 0: // Customer
					return Redirect("/Privacy");
				case 1: // Staff
					return Redirect("/BookingManagement/Index");
				case 2: // Doctor
					return Redirect("/PetManagement/Index");
				default:
					return Redirect("/Error");
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

			// Handle user registration or login based on OAuth info
			string email = authResult.Principal.FindFirstValue(ClaimTypes.Email);
			_logger.LogInformation("OAuth login with email: {email}", email);

			// Proceed with user registration or login logic based on retrieved email

			return Redirect("/Privacy"); // Example redirect after OAuth login
		}

		public IActionResult OnGetAccessDenied()
		{
			return RedirectToPage("/Error");
		}
		*/
	}
}
