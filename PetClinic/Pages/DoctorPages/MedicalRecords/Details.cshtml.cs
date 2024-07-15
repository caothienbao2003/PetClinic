using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.DoctorPages.MedicalRecords
{
    public class DetailsModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DetailsModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

      public MedicalRecord MedicalRecord { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedicalRecords == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.MedicalRecords.FirstOrDefaultAsync(m => m.MedicalRecordId == id);
            if (medicalrecord == null)
            {
                return NotFound();
            }
            else 
            {
                MedicalRecord = medicalrecord;
            }
            return Page();
        }
    }
}
