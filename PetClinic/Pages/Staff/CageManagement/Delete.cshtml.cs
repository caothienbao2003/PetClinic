using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class DeleteModel : PageModel
    {
        private readonly PetClinicContext context;

        public DeleteModel()
        {
            context = new PetClinicContext();
        }

        [BindProperty]
      public Cage Cage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Cages == null)
            {
                return NotFound();
            }

            var cage = await context.Cages.FirstOrDefaultAsync(m => m.CageId == id);

            if (cage == null)
            {
                return NotFound();
            }
            else 
            {
                Cage = cage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || context.Cages == null)
            {
                return NotFound();
            }
            var cage = await context.Cages.FindAsync(id);

            if (cage != null)
            {
                Cage = cage;
                context.Cages.Remove(Cage);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
