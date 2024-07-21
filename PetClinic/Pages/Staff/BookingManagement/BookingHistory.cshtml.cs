using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;

namespace PetClinic.Pages.Staff.BookingManagement
{
    public class BookingHistoryModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;

        public BookingHistoryModel(PetClinicBussinessObject.PetClinicContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                .Include(b => b.Doctor)
                .Include(b => b.Pet)
                .Include(b => b.Schedule)
                .Include(b => b.Service).ToListAsync();
            }
        }
    }
}
