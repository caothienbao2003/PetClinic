using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.BookingManagement
{
    public class BookingConfirmationModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IUserService userService;
        private readonly IShiftService shiftService;
        private readonly IScheduleService scheduleService;
        private readonly IBookingService bookingService;

        public BookingConfirmationModel(IPetService _petService, IUserService _userService, IShiftService _shiftService, IScheduleService _scheduleService, IBookingService _bookingService)
        {
            petService = _petService;
            userService = _userService;
            shiftService = _shiftService;
            scheduleService = _scheduleService;
            bookingService = _bookingService;
        }

        [BindProperty]
        public int SelectedPetId { get; set; }
        [BindProperty]
        public DateTime SelectedDate { get; set; }
        [BindProperty]
        public int SelectedShiftId { get; set; }
        [BindProperty]
        public int SelectedDoctorId { get; set; }

        [BindProperty]
        public User PetOwner { get; set; }

        [BindProperty]
        public Pet Pet { get; set; }

        [BindProperty]
        public Shift SelectedShift { get; set; }
        [BindProperty]
        public User SelectedDoctor { get; set; }


        public void OnGet()
        {
            if (TempData.ContainsKey("SelectedPetId"))
            {
                SelectedPetId = (int)TempData["SelectedPetId"];
            }

            if (TempData.ContainsKey("SelectedDate"))
            {
                SelectedDate = (DateTime)TempData["SelectedDate"];
            }

            if (TempData.ContainsKey("SelectedShiftId"))
            {
                SelectedShiftId = (int)TempData["SelectedShiftId"];
            }

            if (TempData.ContainsKey("SelectedDoctorId"))
            {
                SelectedDoctorId = (int)TempData["SelectedDoctorId"];
            }

            Pet = petService.GetPetById(SelectedPetId);
            SelectedDoctor = userService.GetUserById(SelectedDoctorId);
            SelectedShift = shiftService.GetShiftById(SelectedShiftId);
            PetOwner = Pet.Customer;
        }
        public void OnPost()
        {
            Console.WriteLine("Cf SelectedPetId: " + SelectedPetId);
            Console.WriteLine("Cf SelectedDate: " + SelectedDate);
            Console.WriteLine("Cf SelectedShiftId: " + SelectedShiftId);
            Console.WriteLine("Cf SelectedDoctorId: " + SelectedDoctorId);

            Schedule schedule = scheduleService.GetAvailableScheduleList(SelectedDate, SelectedShiftId, SelectedDoctorId).First();

            Booking newBooking = new Booking
            {
                PetId = SelectedPetId,
                DoctorId = SelectedDoctorId,
                ScheduleId = schedule.ScheduleId,
                BookingAt = DateTime.Now,
                PaymentStatus = (int)BookingPaymentStatus.Unpaid,
                BookingStatus = (int)BookingStatus.Pending,
            };

            bookingService.AddBooking(newBooking);
        }
    }
}
