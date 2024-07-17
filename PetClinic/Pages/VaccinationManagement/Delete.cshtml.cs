using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationManagement
{
    public class DeleteModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DeleteModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public VaccinationDetail VaccinationDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VaccinationDetails == null)
            {
                return NotFound();
            }

            var vaccinationdetail = await _context.VaccinationDetails.FirstOrDefaultAsync(m => m.VaccinationDetailsId == id);

            if (vaccinationdetail == null)
            {
                return NotFound();
            }
            else 
            {
                VaccinationDetail = vaccinationdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.VaccinationDetails == null)
            {
                return NotFound();
            }
            var vaccinationdetail = await _context.VaccinationDetails.FindAsync(id);

            if (vaccinationdetail != null)
            {
                VaccinationDetail = vaccinationdetail;
                _context.VaccinationDetails.Remove(VaccinationDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
