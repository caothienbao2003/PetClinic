using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class CreateModel : PageModel
    {
        private IBookingService bookingService;
        private IUserSerivce userService;
        public CreateModel(IBookingService _bookingService, IUserSerivce _userService)
        {
            bookingService = _bookingService;
            userService = _userService;
        }

        [BindProperty]
        public User CurrentUser { get; set; } = default!;
        [BindProperty]
        public List<Pet> PetList { get; set; }

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
            }

        }

        public void OnPost()
        {
            bookingService.Add(Booking);
        }
    }
}
