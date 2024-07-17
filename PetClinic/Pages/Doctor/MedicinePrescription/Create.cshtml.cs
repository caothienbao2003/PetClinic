using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.DoctorPages.MedicinePrescription
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
        ViewData["PrescriptionDetailsId"] = new SelectList(_context.PrescriptionDetails, "PrescriptionDetailsId", "PrescriptionDetailsId");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Prescriptions == null || Prescription == null)
            {
                return Page();
            }

            _context.Prescriptions.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
