using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }

        private IUserService userService;

        public LoginModel(IUserService _userSerivce)
        {
            userService = _userSerivce;
        }

        public void OnGet()
        {
        }

        public void OnPostLogin()
        {
            var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
            var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

            if (email.Equals(adminEmail) && password.Equals(adminPassword))
            {
                Response.Redirect("/UserManagement/Index");
                return;
            }

            User user = userService.GetUser(email, password);

            if (user == null)
            {
                Response.Redirect("/Authentication/Login");
                return;
            }

            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            switch (user.Role)
            {
                case 0: // Customer
                    Response.Redirect("/Privacy");
                    break;
                case 1: // Staff
                    Response.Redirect("/BookingManagement/Index");
                    break;
                case 2: // Doctor
                    Response.Redirect("/PetManagement/Index");
                    break;
                default:
                    Response.Redirect("/Error");
                    break;
            }
        }
    }
}
