using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetClinic.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
		public void OnGet()
		{
			HttpContext.Session.Clear();
			Response.Redirect("Login");
		}
	}
}
