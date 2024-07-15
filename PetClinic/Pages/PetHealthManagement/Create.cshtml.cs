using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.PetHealthManagement
{
    public class CreateModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public CreateModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
        ViewData["VaccinationRecordsId"] = new SelectList(_context.VaccinationRecords, "VaccinationRecordsId", "VaccinationRecordsId");
            return Page();
        }

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PetHealths == null || PetHealth == null)
            {
                return Page();
            }

            _context.PetHealths.Add(PetHealth);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
