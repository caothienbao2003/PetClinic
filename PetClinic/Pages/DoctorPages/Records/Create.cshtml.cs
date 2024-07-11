using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.DoctorPages.Records
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
        ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
        ViewData["DoctorId"] = new SelectList(_context.Users, "UserId", "FirstName");
        ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId");
        ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return Page();
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MedicalRecords == null || MedicalRecord == null)
            {
                return Page();
            }

            _context.MedicalRecords.Add(MedicalRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
