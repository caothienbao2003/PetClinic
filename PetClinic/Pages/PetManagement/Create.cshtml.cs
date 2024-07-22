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

namespace PetClinic.Pages.PetManagement
{
    public class CreateModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IPetHealthService petHealthService;

        public int userId = 0;
        public string? userIdString;

        public CreateModel(IPetService _petService, IPetHealthService _petHealthService)
        {
            petService = _petService;
            petHealthService = _petHealthService;
        }

        public void OnGet()
        {
            
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty]
        public int PetId { get; set; } = default!;

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public void OnPost()
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

            PetId = Pet.PetId;

            RedirectToPage("/PetHealthManagement/Create", new { petId = PetId });
        }
    }
}
