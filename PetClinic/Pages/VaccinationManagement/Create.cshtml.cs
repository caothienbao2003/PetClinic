using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationManagement
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
        ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedicineId", "MedicineId");
            return Page();
        }

        [BindProperty]
        public VaccinationDetail VaccinationDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.VaccinationDetails == null || VaccinationDetail == null)
            {
                return Page();
            }

            _context.VaccinationDetails.Add(VaccinationDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
