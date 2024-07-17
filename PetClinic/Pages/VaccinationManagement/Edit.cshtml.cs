﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.VaccinationManagement
{
    public class EditModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public EditModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VaccinationRecord record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.VaccinationRecords == null)
            {
                return NotFound();
            }

            var vaccinationdetail =  await _context.VaccinationRecords.FirstOrDefaultAsync(m => m.VaccinationRecordId == id);
            if (vaccinationdetail == null)
            {
                return NotFound();
            }
            record = vaccinationdetail;
           ViewData["MedicineId"] = new SelectList(_context.Medicines, "MedicineId", "MedicineId");
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

            _context.Attach(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinationDetailExists(record.VaccinationRecordId))
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

        private bool VaccinationDetailExists(int id)
        {
          return (_context.VaccinationRecords?.Any(e => e.VaccinationRecordId == id)).GetValueOrDefault();
        }
    }
}