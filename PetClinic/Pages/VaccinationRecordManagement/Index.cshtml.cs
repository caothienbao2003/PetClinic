using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationRecordManagement
{
    public class IndexModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public IndexModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IList<VaccinationRecord> VaccinationRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.VaccinationRecords != null)
            {
                VaccinationRecord = await _context.VaccinationRecords
                .Include(v => v.VaccinationDetails).ToListAsync();
            }
        }
    }
}
