using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.ScheduleManagement
{
    public class IndexModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public IndexModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Schedules != null)
            {
                Schedule = await _context.Schedules
                .Include(s => s.Employee)
                .Include(s => s.Shift).ToListAsync();
            }
        }
    }
}
