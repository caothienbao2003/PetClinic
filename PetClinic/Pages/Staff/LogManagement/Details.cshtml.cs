using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Staff.LogManagement
{
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

      public HospitalizeLog HospitalizeLog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HospitalizeLogs == null)
            {
                return NotFound();
            }

            var hospitalizelog = await _context.HospitalizeLogs.FirstOrDefaultAsync(m => m.HospitalizeLogId == id);
            if (hospitalizelog == null)
            {
                return NotFound();
            }
            else 
            {
                HospitalizeLog = hospitalizelog;
            }
            return Page();
        }
    }
}
