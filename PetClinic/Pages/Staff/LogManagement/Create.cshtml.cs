using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Staff.LogManagement
{
    public class CreateModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public CreateModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["HospitalizeId"] = new SelectList(_context.Hospitalizes, "HospitalizeId", "HospitalizeId");
            return Page();
        }

        [BindProperty]
        public HospitalizeLog HospitalizeLog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.HospitalizeLogs == null || HospitalizeLog == null)
            {
                return Page();
            }

            _context.HospitalizeLogs.Add(HospitalizeLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
