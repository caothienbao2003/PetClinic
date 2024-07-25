using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IUserService userService;

        public DeleteModel(IPetService _petService, IUserService _userService)
        {
            petService = _petService;
            userService = _userService;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty]
        public User user { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PetId { get; set; }

        public IActionResult OnGet(int id)
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

            PetId = id;

            var pet = petService.GetPetById(PetId);

            if (pet == null)
            {
                return NotFound();
            }

            Pet = pet;

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            PetId = id;

            var pet = petService.GetPetById(PetId);

            if (pet != null)
            {
                Pet = pet;
                petService.RemovePet(Pet.PetId);
            }

            return Page();
        }
    }
}
