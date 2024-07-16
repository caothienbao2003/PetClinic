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
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

      public VaccinationRecord record { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VaccinationRecords == null)
            {
                return NotFound();
            }

            var vaccinationdetail = await _context.VaccinationRecords.FirstOrDefaultAsync(m => m.VaccinationRecordId == id);
            if (vaccinationdetail == null)
            {
                return NotFound();
            }
            else 
            {
                record = vaccinationdetail;
            }
            return Page();
        }
    }
}
