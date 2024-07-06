using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetClinic.Pages.Authentication
{
    public class RegisterModel : PageModel
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

        public void OnGet()
        {
        }

        public void OnPostAsync()
        {

        }
    }
}
