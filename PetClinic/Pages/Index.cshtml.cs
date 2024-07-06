using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;


namespace PetClinic.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public string userName { get; set; }
		[BindProperty]
		public string password { get; set; }

		private IUserService userSerivce;

		public IndexModel(IUserService _userSerivce)
		{
			userSerivce = _userSerivce;
		}

		public void OnGet()
		{

		}

		public void OnPost()
		{

		}

		public void OnPostLogin()
		{
			Response.Redirect("Authentication/Login");
		}

        public void OnPostRegister()
		{
			Response.Redirect("Authentication/CustomerRegister");
        }


    }
}
