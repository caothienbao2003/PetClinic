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
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingService bookingService;

        public BookingHistoryModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [BindProperty]
        public List<Booking> BookingList { get; set; } = default!;

        public void OnGet()
        {
            BookingList = bookingService.GetAll();
        }
    }
}
