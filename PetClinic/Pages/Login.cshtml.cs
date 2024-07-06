using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string userName { get; set; }
        [BindProperty]
        public string password { get; set; }

        private IUserSerivce userSerivce;

        public LoginModel(IUserSerivce _userSerivce)
        {
            userSerivce = _userSerivce;
        }

        public void OnGet()
        {
        }

        public void OnPostLogin()
        {
			User user = userSerivce.GetUser(userName, password);
			if (user.Role == 1 && user != null)
			{
				Response.Redirect("/UserManagement/Index");
			}
			else
			{
				Response.Redirect("/Error");
			}
		}
    }
}
