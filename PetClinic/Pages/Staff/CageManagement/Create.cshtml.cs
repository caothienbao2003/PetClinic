using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class CreateModel : PageModel
    {
        private readonly ICageService cageService;

        public CreateModel(ICageService _cageService)
        {
            cageService = _cageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
          if (!ModelState.IsValid || Cage == null)
            {
                return Page();
            }

            cageService.AddCage(Cage);

            return RedirectToPage("./Index");
        }
    }
}
