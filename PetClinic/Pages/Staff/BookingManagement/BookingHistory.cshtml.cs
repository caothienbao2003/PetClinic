using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.BookingManagement
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingService bookingService;
        private readonly IShiftService shiftService;

        public BookingHistoryModel(IBookingService _bookingService, IShiftService _shiftService)
        {
            bookingService = _bookingService;
            shiftService = _shiftService;
        }

        [BindProperty]
        public DateTime? StartDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }
        [BindProperty]
        public string? DoctorName { get; set; }
        [BindProperty]
        public string? CustomerName { get; set; }
        [BindProperty]
        public string? PetName { get; set; }
        [BindProperty]
        public BookingPaymentStatus? PaymentStatus { get; set; }
        [BindProperty]
        public BookingStatus? BookingStatusFilter { get; set; }

        [BindProperty]
        public List<Booking> BookingList { get; set; } = default!;
        [BindProperty]
        public List<Shift> ShiftList { get; set; } = default!;
        [BindProperty]
        public int? ShiftId {  get; set; }
        public void OnGet()
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            BookingList = bookingService.GetAll();
        }

        public void OnPostSearch()
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            BookingList = bookingService.SearchBy(StartDate, EndDate, (int?)PaymentStatus, (int?)BookingStatusFilter, ShiftId, DoctorName, CustomerName, PetName);

            Console.WriteLine("Search");
        }

        public void OnPostConfirm(int? detail)
        {
            if (detail == null)
            {
                return;
            }

            var booking = bookingService.GetBookingById(detail.Value);

            if (booking != null)
            {
                booking.BookingStatus = (int)BookingStatus.Pending;

                bookingService.UpdateBooking(booking);
            }

			Response.Redirect("./BookingHistory");
        }

        public void OnPostCancel(int? id)
        {
            if (id == null)
            {
                return;
            }

            var booking = bookingService.GetBookingById(id.Value);

            if (booking != null)
            {
                booking.BookingStatus = (int)BookingStatus.Canceled;

                bookingService.UpdateBooking(booking);
            }

            Response.Redirect("./BookingHistory");
        }
        public void OnPostChooseDoctor(int? id)
        {
            if (id == null)
            {
                return;
            }

            TempData["BookingId"] = id.Value;

            Response.Redirect("/ChooseDoctor");
        }
    }
}
