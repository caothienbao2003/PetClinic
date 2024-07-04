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
    public class DetailsModel : PageModel
    {
        private readonly PetClinicContext context;

        public DetailsModel()
        {
            context = new PetClinicContext();
        }

        public Hospitalize Hospitalize { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Hospitalizes == null)
            {
                return NotFound();
            }

            var hospitalize = await context.Hospitalizes.FirstOrDefaultAsync(m => m.HospitalizeId == id);
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
    }
}
