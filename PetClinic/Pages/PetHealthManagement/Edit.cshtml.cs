using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.PetHealthManagement
{
    public class EditModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public EditModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PetHealths == null)
            {
                return NotFound();
            }

            var pethealth =  await _context.PetHealths.FirstOrDefaultAsync(m => m.PetHealthId == id);
            if (pethealth == null)
            {
                return NotFound();
            }
            PetHealth = pethealth;
           ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
           ViewData["VaccinationRecordsId"] = new SelectList(_context.VaccinationRecords, "VaccinationRecordsId", "VaccinationRecordsId");
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

            _context.Attach(PetHealth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetHealthExists(PetHealth.PetHealthId))
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

        private bool PetHealthExists(int id)
        {
          return (_context.PetHealths?.Any(e => e.PetHealthId == id)).GetValueOrDefault();
        }
    }
}
