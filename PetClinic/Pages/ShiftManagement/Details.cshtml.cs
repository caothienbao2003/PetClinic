using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.ShiftManager
{
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

      public Shift Shift { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shifts == null)
            {
                return NotFound();
            }

            var shift = await _context.Shifts.FirstOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }
            else 
            {
                Shift = shift;
            }
            return Page();
        }
    }
}
