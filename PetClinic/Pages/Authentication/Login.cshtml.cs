using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string email { get; set; }
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
            var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
            var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

            User user = userSerivce.GetUser(email, password);
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (email.Equals(adminEmail)) //admin
            {
                if (adminPassword.Equals(password))
                {
                    Response.Redirect("/UserManagement/Index");
                }
            }
            else if (user.Role == 0 && user != null) //customer
            {
                Response.Redirect("Privacy");
            }
            else if (user.Role == 1 && user != null) //staff
            {
                Response.Redirect("/BookingManagement/Index");
            }
            else if (user.Role == 2 && user != null) //doctor
            {
                Response.Redirect("/PetManagement/Index");
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
    }
}
