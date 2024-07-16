using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Staff.LogManagement
{
    public class EditModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public EditModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HospitalizeLog HospitalizeLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HospitalizeLogs == null)
            {
                return NotFound();
            }

            var hospitalizelog =  await _context.HospitalizeLogs.FirstOrDefaultAsync(m => m.HospitalizeLogId == id);
            if (hospitalizelog == null)
            {
                return NotFound();
            }
            HospitalizeLog = hospitalizelog;
           ViewData["HospitalizeId"] = new SelectList(_context.Hospitalizes, "HospitalizeId", "HospitalizeId");
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

            _context.Attach(HospitalizeLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizeLogExists(HospitalizeLog.HospitalizeLogId))
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

        private bool HospitalizeLogExists(int id)
        {
          return (_context.HospitalizeLogs?.Any(e => e.HospitalizeLogId == id)).GetValueOrDefault();
        }
    }
}
