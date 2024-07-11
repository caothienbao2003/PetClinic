using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.DoctorPages
{
    public class BookingViewModel : PageModel
    {
        private IBookingService bookingService;
        private IUserService userService;

        public BookingViewModel(IBookingService _bookingService, IUserService _userService)
        {
            bookingService = _bookingService;
            userService = _userService;
        }

        [BindProperty]
        public List<Booking> BookingList { get; set; } = default!;
        [BindProperty]
        public User CurrentUser { get; set; } = default!;

        public IActionResult OnGet()
        {
            BookingList = bookingService.GetAll();
            //string userIdString = HttpContext.Session.GetString("UserId");

            //if (userIdString != null)
            //{
            //    int userId = int.Parse(userIdString);
            //    CurrentUser = userService.GetUserById(userId);
            //}



            return Page();
        }
    }
}
