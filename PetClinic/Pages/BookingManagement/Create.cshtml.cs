using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class CreateModel : PageModel
    {
        private IBookingService bookingService;
        private IPetService petService;
        public CreateModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public void OnGet()
        {

        }

        public void OnPost()
        {
            bookingService.Add(Booking);
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //  if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
        //    {
        //        return Page();
        //    }

        //    _context.Bookings.Add(Booking);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
