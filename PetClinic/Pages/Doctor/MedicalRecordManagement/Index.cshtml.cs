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
    public class IndexModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public IndexModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IList<MedicalRecord> MedicalRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MedicalRecords != null)
            {
                MedicalRecord = await _context.MedicalRecords
                .Include(m => m.Booking)
                .Include(m => m.Doctor)
                .Include(m => m.Service).ToListAsync();
            }
        }
    }
}
