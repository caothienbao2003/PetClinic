using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class DeleteModel : PageModel
    {
        private readonly PetClinicContext _context;

        public DeleteModel(PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hospitalize Hospitalize { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hospitalizes == null)
            {
                return NotFound();
            }

            var hospitalize = await _context.Hospitalizes.FirstOrDefaultAsync(m => m.HospitalizeId == id);

            if (hospitalize == null)
            {
                return NotFound();
            }
            else
            {
                Hospitalize = hospitalize;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hospitalizes == null)
            {
                return NotFound();
            }
            var hospitalize = await _context.Hospitalizes.FindAsync(id);

            if (hospitalize != null)
            {
                Hospitalize = hospitalize;
                _context.Hospitalizes.Remove(Hospitalize);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
