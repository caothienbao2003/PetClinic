using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;
using System.Net;

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

        public IActionResult OnPostRegister()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

			if (string.IsNullOrEmpty(email) 
                || string.IsNullOrEmpty(password)
				|| string.IsNullOrEmpty(phoneNumber)
				|| string.IsNullOrEmpty(address)
				|| string.IsNullOrEmpty(email)
				|| string.IsNullOrEmpty(gender))
			{
				_logger.LogWarning("Information is empty");
				return Page();
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

            return RedirectToPage("/Authentication/Login");
        }
    }
}
