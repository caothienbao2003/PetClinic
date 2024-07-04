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
    public class DetailsModel : PageModel
    {
        private readonly PetClinicContext context;

        public DetailsModel()
        {
            context = new PetClinicContext();
        }

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
    }
}
