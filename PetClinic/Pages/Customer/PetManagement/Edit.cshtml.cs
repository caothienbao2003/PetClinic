using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class EditModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IUserService userService;
        private readonly IPetHealthService petHealthService;

        public int userId = 0;
        public string? userIdString;

        public EditModel(IPetService _petService, IUserService _userService
        , IPetHealthService _petHealthService)
        {
            petService = _petService;
            userService = _userService;
            petHealthService = _petHealthService;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PetId { get; set; }

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;

        [BindProperty]
        public User user { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            PetId = id;

            var pet = petService.GetPetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            Pet = pet;

            var petHealth = petService.GetPetHealthByPetId(PetId);

            if (petHealth == null)
            {
                return NotFound();
            }

            PetHealth = petHealth;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Clear();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "ModelState is NOT valid");
                return Page();
            }

            Pet existingPet = petService.GetPetById(PetId);
            PetHealth existingPetHealth = petHealthService.GetPetHealthByPetId(PetId);
            if (existingPet == null)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating pet.");
                return Page();
            }

            if (existingPetHealth == null)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating pet health.");
                return Page();
            }

            try
            {
                existingPet.PetName = Pet.PetName;
                existingPet.PetType = Pet.PetType;
                existingPet.PetAge = Pet.PetAge;
                existingPetHealth.OverallHealth = PetHealth.OverallHealth;
                existingPetHealth.Conditions = PetHealth.Conditions;
                existingPetHealth.Weight = PetHealth.Weight;
                existingPetHealth.WeightMeasurementDate = PetHealth.WeightMeasurementDate;

                petService.UpdatePet(existingPet);
                petHealthService.UpdatePetHealth(existingPetHealth);
                return RedirectToPage("/Customer/PetManagement/Index", new {id = PetId});
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating pet.");
                return Page();
            }
        }
    }
}
