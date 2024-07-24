using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.BookingManagement
{
    public class BookingHistoryModel : PageModel
    {
        private readonly IBookingService bookingService;
        private readonly IScheduleService scheduleService;

        public BookingHistoryModel(IBookingService _bookingService, IScheduleService scheduleService)
        {
            bookingService = _bookingService;
            this.scheduleService = scheduleService;
        }

        public List<Booking> BookingList { get; set; } = default!;

        public void OnGet()
        {

            LoadBookingList();
            Console.WriteLine("Get");
        }

        public void OnPostCancel(int id)
        {
            Booking cancelBooking = bookingService.GetBookingById(id);

            if (cancelBooking == null)
            {
                return;
            }

            cancelBooking.BookingStatus = (int)BookingStatus.Canceled;


            //Schedule schedule = cancelBooking.Schedule;

            //Update schedule number of occupation
            //int occupation = schedule.NoOfOccupation ?? default(int);
            //occupation--;
            //schedule.NoOfOccupation = occupation;

            //scheduleService.UpdateSchedule(schedule);
            bookingService.UpdateBooking(cancelBooking);

            LoadBookingList();
        }

        public void OnPostDetail(int detail)
        {
            Console.WriteLine("Detail id: " + detail);
            
            TempData["BookingId"] = detail;
            LoadBookingList();

            Response.Redirect("/Customer/BookingManagement/BookingDetail");
        }

        private void LoadBookingList()
        {
            string userIdString = HttpContext.Session.GetString("UserId");

            if (userIdString == null)
            {
                Response.Redirect("/Authentication/Login");
                return;
            }

            int userId = int.Parse(userIdString);

            BookingList = bookingService.GetBookingListByUserId(userId);

            Console.WriteLine("Count: " + BookingList.Count);
        }

    }
}
