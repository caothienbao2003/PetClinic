using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationRecordManagement
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
        ViewData["VaccinationDetailsId"] = new SelectList(_context.VaccinationDetails, "VaccinationDetailsId", "VaccinationDetailsId");
            return Page();
        }

        [BindProperty]
        public VaccinationRecord VaccinationRecord { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.VaccinationRecords == null || VaccinationRecord == null)
            {
                return Page();
            }

            _context.VaccinationRecords.Add(VaccinationRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
