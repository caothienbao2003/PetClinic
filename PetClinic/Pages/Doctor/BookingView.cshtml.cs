using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor
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
        public User user { get; set; } = default!;

        [BindProperty]
        public DateTime? StartDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }

        [BindProperty]
        public BookingStatus? BookingStatus { get; set; }

        [BindProperty]
        public string? CustomerName { get; set; }

        [BindProperty]
        public string? PetName { get; set; }

        public IActionResult OnGet()
        {
            BookingList = bookingService.GetAll();
            string userIdString = HttpContext.Session.GetString("UserId")!;

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);
                user = userService.GetUserById(userId);


                BookingList = bookingService.GetAll()
                        .Where(b => b.DoctorId == userId)
                        .OrderBy(b => (int)b.BookingStatus!)
                        .ToList();
            }

            return Page();
        }

        public void OnPostSearch()
        {
            BookingList = bookingService.SearchBy(StartDate, EndDate, null, (int?)BookingStatus, null, null, CustomerName, PetName);

            Console.WriteLine("Search");
        }
    }
}
