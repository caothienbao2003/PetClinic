using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class EditModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public EditModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pet =  await _context.Pets.FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }
            Pet = pet;
           ViewData["CustomerId"] = new SelectList(_context.Users, "UserId", "Password");
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

            _context.Attach(Pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(Pet.PetId))
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

        private bool PetExists(int id)
        {
          return (_context.Pets?.Any(e => e.PetId == id)).GetValueOrDefault();
        }
    }
}
