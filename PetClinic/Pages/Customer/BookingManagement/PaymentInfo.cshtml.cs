using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.BookingManagement
{
    public class PaymentInfoModel : PageModel
    {
        private readonly IBookingService bookingService;

        public PaymentInfoModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [BindProperty]
        public string BankAccountNumber { get; set; }
        [BindProperty]
        public string BankAccountOwnerName { get; set; }
        [BindProperty]
        public string BankName { get; set; }
        [BindProperty]
        public string BankImage { get; set; }
        [BindProperty]
        public string QrCodeImage { get; set; }

        public void OnGet()
        {
            BankAccountNumber = "0123456789";
            BankAccountOwnerName = "Pet Clinic";
            BankName = "TP Bank";
            BankImage = "https://media.loveitopcdn.com/3807/logo-tpbank-2.jpg";
            QrCodeImage = "https://images.viblo.asia/2b174eac-50bd-40c0-91c8-bbecab2093b5.png";
        }

        public void OnPostPay()
        {
            string? bookingIdString = TempData["BookingId"].ToString();

            if (bookingIdString == null)
            {
                Response.Redirect("/Error");
            }

            int bookingId = int.Parse(bookingIdString);

            Booking booking = bookingService.GetBookingById(bookingId);

            if (booking == null)
            {
                Response.Redirect("/Error");
            }
            else
            {
                booking.BookingAt = DateTime.Now;
                booking.BookingStatus = (int)BookingStatus.Pending;
                booking.PaymentStatus = (int)BookingPaymentStatus.Paid;
            }

        }
    }
}
