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
        private IUserService userService;

        [BindProperty]
        public List<Booking> BookingList { get; set; } = default!;
        [BindProperty]
        public User CurrentUser { get; set; } = default!;

        public IndexModel(IBookingService _bookingService, IUserService _userService)
        {
            bookingService = _bookingService;
            userService = _userService;
        }


        public void OnGet()
        {
            BookingList = bookingService.GetAll();
            string userIdString = HttpContext.Session.GetString("UserId");

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);
                CurrentUser = userService.GetUserById(userId);
            }
        }
    }
}
