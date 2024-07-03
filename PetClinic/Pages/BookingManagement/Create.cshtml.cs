using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.BookingManagement
{
    public class CreateModel : PageModel
    {
        private readonly PetClinicBussinessObject.ClinicPetContext _context;

        public CreateModel(PetClinicBussinessObject.ClinicPetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Users, "UserId", "Password");
        ViewData["DoctorShiftId"] = new SelectList(_context.DoctorShifts, "DoctorShiftId", "DoctorShiftId");
        ViewData["PetId"] = new SelectList(_context.Pets, "PetId", "PetId");
        ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
            {
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
