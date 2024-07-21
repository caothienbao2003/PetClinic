using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.BookingManagement
{
    public class BookingDetailModel : PageModel
    {
        private readonly IBookingService bookingService;

        public BookingDetailModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public void OnGet(int? id)
        {
            if (id == null)
            {
                return;
            }

            var booking = bookingService.GetBookingById(id.Value);
            if (booking != null)
            {
                Booking = booking;
            }
        }

        public void OnPostConfirmPayment(int? id)
        {
            if (id == null)
            {
                return;
            }

            var booking = bookingService.GetBookingById(id.Value);

            if(booking.BookingStatus == (int)BookingStatus.Canceled)
            {
                TempData["Message"] = "Booking has been canceled!";
            }

            if(booking.PaymentStatus == (int)BookingPaymentStatus.Paid)
            {
                TempData["Message"] = "Booking has been paid!";
            }

            if (booking != null)
            {
                booking.BookingStatus = (int)BookingStatus.Pending;
                booking.PaymentStatus = (int)BookingPaymentStatus.Paid;

                bookingService.UpdateBooking(booking);
            }

            Booking = booking;
            Response.Redirect("./BookingHistory");
        }
    }
}
