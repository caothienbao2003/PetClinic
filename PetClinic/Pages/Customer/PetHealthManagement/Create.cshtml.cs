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
        public int PetId { get; set; } = default!;

        [BindProperty]
        public User user { get; set; } = default!;

        public void OnGet()
        {
            if (TempData["PetId"] is int petId)
            {
                PetId = petId;
            }
            else
            {
                Response.Redirect("/Customer/PetManagement/Index");
            }
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

            PetHealth.PetId = PetId;
            petHealthService.AddPetHealth(PetHealth);
            
            return RedirectToPage("/Customer/PetManagement/Index") ;
        }
    }
}
