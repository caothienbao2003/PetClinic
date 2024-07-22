using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Customer.PetHealthManagement
{
    public class DeleteModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DeleteModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PetHealth PetHealth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PetHealths == null)
            {
                return NotFound();
            }

            var pethealth = await _context.PetHealths.FirstOrDefaultAsync(m => m.PetHealthId == id);

            if (pethealth == null)
            {
                return NotFound();
            }
            else 
            {
                PetHealth = pethealth;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PetHealths == null)
            {
                return NotFound();
            }
            var pethealth = await _context.PetHealths.FindAsync(id);

            if (pethealth != null)
            {
                PetHealth = pethealth;
                _context.PetHealths.Remove(PetHealth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
