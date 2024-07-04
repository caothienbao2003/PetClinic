using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class EditModel : PageModel
    {
        private readonly PetClinicContext context;

        public EditModel()
        {
            context = new PetClinicContext();
        }

        [BindProperty]
        public Hospitalize Hospitalize { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || context.Hospitalizes == null)
            {
                return NotFound();
            }

            var hospitalize = await context.Hospitalizes.FirstOrDefaultAsync(m => m.HospitalizeId == id);
            if (hospitalize == null)
            {
                return NotFound();
            }
            Hospitalize = hospitalize;
            ViewData["CageId"] = new SelectList(context.Cages, "CageId", "CageId");
            ViewData["DoctorId"] = new SelectList(context.Users, "UserId", "UserId");
            ViewData["PetId"] = new SelectList(context.Pets, "PetId", "PetId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(Hospitalize).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizeExists(Hospitalize.HospitalizeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HospitalizeExists(int id)
        {
            return (context.Hospitalizes?.Any(e => e.HospitalizeId == id)).GetValueOrDefault();
        }
    }
}
