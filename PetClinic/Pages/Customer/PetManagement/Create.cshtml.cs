using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class CreateModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IUserService userService;

        public int userId = 0;
        public string? userIdString;

        public CreateModel(IPetService _petService, IUserService _userService)
        {
            petService = _petService;
            userService = _userService;
        }

        public void OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }
        }

        [BindProperty]
        public User user { get; set; } = default!;

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty]
        public int PetId { get; set; } = default!;

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;


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

            Pet.CustomerId = userId;
            Pet.ActiveStatus = 1;
            petService.AddPet(Pet);

            TempData["PetId"] = Pet.PetId;

            return RedirectToPage("/Customer/PetHealthManagement/Create");
        }
    }
}
