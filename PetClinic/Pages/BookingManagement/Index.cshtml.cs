using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class IndexModel : PageModel
    {
        private IBookingService bookingService;

        public IndexModel(IBookingService _bookingService)
        {
            bookingService = _bookingService;
        }

        [BindProperty]
        public List<Booking> BookingList { get;set; } = default!;

        public void OnGet()
        {
            BookingList = bookingService.GetAll();
        }
    }
}
