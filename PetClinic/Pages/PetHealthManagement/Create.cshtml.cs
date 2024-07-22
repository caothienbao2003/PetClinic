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

namespace PetClinic.Pages.PetHealthManagement
{
    public class CreateModel : PageModel
    {
        private readonly IPetHealthService petHealthService;

        public int userId = 0;
        public string? userIdString;

        public CreateModel(IPetHealthService _petHealthService)
        {
            petHealthService = _petHealthService;
        }

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;

        [BindProperty]
        public int PetId { get; set; } = default!;

        public void OnGet(int petId)
        {
            PetId = petId;
            PetHealth = petHealthService.GetPetHealthByPetId(PetId);
        }

        public async Task<IActionResult> OnPostAsync()
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


            if (!ModelState.IsValid)
            {
                return Page();
            }
            petHealthService.AddPetHealth(PetHealth);

            return RedirectToPage("/PetManagement/Index");
        }
    }
}
