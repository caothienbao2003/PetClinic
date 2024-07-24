using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetHealthManagement
{
    public class CreateModel : PageModel
    {
        private readonly IPetHealthService petHealthService;
        private readonly IUserService userService;

        public int userId = 0;
        public string? userIdString;

        public CreateModel(IPetHealthService _petHealthService, IUserService _userService)
        {
            petHealthService = _petHealthService;
            userService = _userService;
        }

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;

        [BindProperty]
        public int newPetId { get; set; } = default!;

        [BindProperty]
        public User user { get; set; } = default!;

        public IActionResult OnGet(int petId)
        {
            userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString.IsNullOrEmpty())
            {
                Response.Redirect("/Authentication/Login");
            }
            else
            {
                userId = int.Parse(userIdString);
            }

            newPetId = petId;
            PetHealth = new PetHealth { PetId = newPetId };
            return Page();
        }

        public IActionResult OnPost()
        {
            userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString.IsNullOrEmpty())
            {
                Response.Redirect("/Authentication/Login");
            }
            else
            {
                userId = int.Parse(userIdString);
            }

            petHealthService.AddPetHealth(PetHealth);
            
            return RedirectToPage("/Customer/PetManagement/Index") ;
        }
    }
}
