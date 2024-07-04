using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.BookingManagement
{
    public class DeleteModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public DeleteModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);

            if (booking != null)
            {
                Booking = booking;
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
