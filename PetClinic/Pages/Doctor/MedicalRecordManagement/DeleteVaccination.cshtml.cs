using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class DeleteVaccinationModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DeleteVaccinationModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public VaccinationRecord VaccinationRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VaccinationRecords == null)
            {
                return NotFound();
            }

            var vaccinationrecord = await _context.VaccinationRecords.FirstOrDefaultAsync(m => m.VaccinationRecordId == id);

            if (vaccinationrecord == null)
            {
                return NotFound();
            }
            else 
            {
                VaccinationRecord = vaccinationrecord;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.VaccinationRecords == null)
            {
                return NotFound();
            }
            var vaccinationrecord = await _context.VaccinationRecords.FindAsync(id);

            if (vaccinationrecord != null)
            {
                VaccinationRecord = vaccinationrecord;
                _context.VaccinationRecords.Remove(VaccinationRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
