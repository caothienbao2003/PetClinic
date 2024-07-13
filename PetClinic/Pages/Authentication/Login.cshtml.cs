using MessagePack;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices;
using PetClinicServices.Interface;
using System;
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
			bool isAdmin = userService.IsAdmin(new() { Email = email, Password = password });

			if (isAdmin)
			{
				Response.Redirect("/Admin/AdminHomePage");
			}
			else
			{
				User user = userService.GetUserByEmail(email);

				if (user != null && DAOUtilities.Instance.VerifyPassword(password, user.Password))
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

		public async Task<IActionResult> OnGetExternalLogin(string provider)
		{
			var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback");
			var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
			return new ChallengeResult(provider, properties);
		}

		public async Task<IActionResult> OnGetExternalLoginCallback()
		{
			var authResult = await HttpContext.AuthenticateAsync();
			
			if (!authResult.Succeeded)
			{
				return RedirectToPage("/Error");
			}
			else
			{
				Console.WriteLine(authResult.Principal.FindFirstValue(ClaimTypes.Email));
				string email = authResult.Principal.FindFirstValue(ClaimTypes.Email);

				User user = userService.GetUserByEmail(email);

				Console.WriteLine(user == null);

				if (user != null)
				{
					HttpContext.Session.SetString("UserId", user.UserId.ToString());
					HttpContext.Session.SetString("Role", user.Role.ToString());

					return RedirectToPage("/Privacy");
				}
				else
				{
					TempData["NewEmail"] = authResult.Principal.FindFirstValue(ClaimTypes.Email);
					return RedirectToPage("/Authentication/CustomerRegisterByGoogle");
				}
				
			}
		}
	}
}
