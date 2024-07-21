using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicRepository.Interface;

namespace PetClinic.Pages.Staff.BookingManagement
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingRepository bookingRepository;

        public BookingHistoryModel(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository;
        }

        public List<Booking> BookingList { get; set; } = default!;

        public void OnGet()
        {
            BookingList = bookingRepository.GetAll();
        }
    }
}
