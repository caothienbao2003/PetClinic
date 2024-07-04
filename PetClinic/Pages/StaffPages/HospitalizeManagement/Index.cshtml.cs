using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class IndexModel : PageModel
    {
        private readonly PetClinicContext context;

        public IndexModel()
        {
            context = new PetClinicContext();
        }

        public IList<Hospitalize> Hospitalize { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (context.Hospitalizes != null)
            {
                Hospitalize = await context.Hospitalizes
                .Include(h => h.Cage)
                .Include(h => h.Doctor)
                .Include(h => h.Pet).ToListAsync();
            }
        }
    }
}
