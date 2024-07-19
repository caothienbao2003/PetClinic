using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.BookingManagement
{
    public class BookingDetailModel : PageModel
    {
        private readonly IBookingService bookingService;

        private int bookingId;

        public BookingDetailModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        public Booking Booking { get; set; } = default!;

        public void OnGet()
        {
            if (TempData.ContainsKey("BookingId"))
            {
                bookingId = (int)TempData["BookingId"];
                TempData.Keep("BookingId");
            }
            else
            {
                Response.Redirect("/Error");
            }

            var booking = bookingService.GetBookingById(bookingId);
            if (booking == null)
            {
                Response.Redirect("/Error");
                return;
            }
            else
            {
                Booking = booking;
            }
        }
    }
}
