using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.PetManagement
{
    public class CreateModel : PageModel
    {
        private readonly IPetService petService;

        public int? userId = 0;
        public string? userIdString;

        public CreateModel(IPetService _petService)
        {
            petService = _petService;
        }

        public void OnGet()
        {
            userIdString = HttpContext.Session.GetString("UserId");
            if(userIdString == null)
            {
                Response.Redirect("/Privacy");
            }
            else
            {
                userId = int.Parse(userIdString);
            }
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public void OnPost()
        {
            Pet.CustomerId = userId;
            petService.AddPet(Pet);
        }
    }
}
