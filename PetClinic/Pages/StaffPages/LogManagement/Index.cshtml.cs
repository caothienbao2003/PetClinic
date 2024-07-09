using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.LogManagement
{
    public class IndexModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public IndexModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IList<HospitalizeLog> HospitalizeLog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.HospitalizeLogs != null)
            {
                HospitalizeLog = await _context.HospitalizeLogs
                .Include(h => h.Hospitalize).ToListAsync();
            }
        }
    }
}
