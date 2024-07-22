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
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

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
    }
}
