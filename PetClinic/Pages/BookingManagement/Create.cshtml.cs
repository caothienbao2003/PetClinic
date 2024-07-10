using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;
using PetClinicDAO;

namespace PetClinic.Pages.BookingManagement
{
    public class CreateModel : PageModel
    {
        private IBookingService bookingService;
        private IUserService userService;
        private IShiftService shiftService;
        private IDoctorService doctorService;

        public CreateModel(IBookingService _bookingService, IUserService _userService, IShiftService _shiftService, IDoctorService _doctorService)
        {
            bookingService = _bookingService;
            userService = _userService;
            shiftService = _shiftService;
            doctorService = _doctorService;
        }

        [BindProperty]
        public User CurrentUser { get; set; } = default!;
        [BindProperty]
        public List<Pet> PetList { get; set; }
        [BindProperty]
        public List<Shift> ShiftList { get; set; }  // Shifts
        [BindProperty]
        public List<User> DoctorList { get; set; }  // Doctors
        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public DateTime MinDate { get; set; }

        public void OnGet()
        {
            MinDate = DateTime.Now.AddDays(1);
            string userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);
                CurrentUser = userService.GetUserById(userId);
                PetList = CurrentUser.Pets.ToList();
                ViewData["PetId"] = new SelectList(PetList, "PetId", "PetName");

                // Fetch available shifts and doctors
                ShiftList = shiftService.GetAllShifts();
                //ShiftList = ShiftDAO.Instance.GetAllShiftWithShiftType(ShiftType.Doctor);
                DoctorList = doctorService.GetAllDoctors();
                ViewData["ShiftId"] = new SelectList(ShiftList, "ShiftId", "ShiftTime");
                ViewData["DoctorId"] = new SelectList(DoctorList, "DoctorId", "DoctorName");
            }
        }

        public void OnPost()
        {
            bookingService.Add(Booking);
        }
    }
}
