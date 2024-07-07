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

		public LoginModel(IUserService _userService)
		{
			userService = _userService;
		}


		public void OnPostLogin()
		{
			var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
			var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

			if (email == adminEmail)
			{
				if (password == adminPassword)
				{
					Response.Redirect("/UserManagement/Index");
				}
			}
			else
			{
				User user = userService.GetUser(email, password);

				if (user != null)
				{
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
				}
				else
				{
					return;
				}
			}


		}


		// Handle external login
		public async Task<IActionResult> OnGetExternalLogin(string provider)
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
