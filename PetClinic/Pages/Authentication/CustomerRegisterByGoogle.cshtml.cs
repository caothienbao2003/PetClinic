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
	public class CustomerRegisterByGoogleModel : PageModel
	{
		[BindProperty]
		public string firstName { get; set; }
		[BindProperty]
		public string lastName { get; set; }
		[BindProperty]
		public string socialNumber { get; set; }


		public string password = "1234567890";
		[BindProperty]
		public string phoneNumber { get; set; }
		[BindProperty]
		public string address { get; set; }

		[BindProperty]
		public string email { get; set; }
		[BindProperty]
		public string gender { get; set; }

		private readonly IUserService userService;
		public CustomerRegisterByGoogleModel(IUserService _userService)
		{
			userService = _userService;
		}

		public void OnGet()
		{
			if (TempData.ContainsKey("NewEmail"))
			{
				email = (string)TempData["NewEmail"];
			}

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
				Password = password,
				PhoneNumber = phoneNumber,
				Address = address,
				Email = email,
				Gender = gender,
				Role = 0 //0 is the role for a customer
			};

			userService.AddUser(newUser);

			Response.Redirect("/HomePages/CustomerHomePage");
		}
	}
}
