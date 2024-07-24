using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class BookingDAO
    {
        private readonly PetClinicContext context;

        private static BookingDAO? instance;

        public BookingDAO()
        {
            context = new PetClinicContext();
        }

        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDAO();
                }
                return instance;
            }
        }

        public List<Booking> GetAllBooking()
        {
            return context.Bookings
                .Include(b => b.Pet)
                .Include(b => b.Pet.Customer)
                .Include(b => b.Doctor)
                .Include(b => b.Schedule)
                .Include(b => b.Service)
                .Include(b => b.Schedule.Shift)
                .Include(b => b.Doctor)
                .ToList();
        }

        public Booking? GetBookingById(int id)
        {
            return context.Bookings.Include(p => p.Pet).FirstOrDefault(b => b.BookingId == id);
        }

        public void Add(Booking booking)
        {
            if (GetBookingById(booking.BookingId) != null)
            {
                return;
            }

            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            if (GetBookingById(booking.BookingId) == null)
            {
                return;
            }

            context.Bookings.Update(booking);
            context.SaveChanges();
        }
        public Booking GetBooking(int petId, int scheduleId)
        {
            return context.Bookings
                .Include(p => p.Pet)
                .Include(d => d.Doctor)
                .Include(s => s.Schedule)
                .Include(s => s.Service)
                .FirstOrDefault(b => b.PetId == petId && b.ScheduleId == scheduleId)!;
        }

        public Booking GetExistedBookingList(int petId, DateTime date, int shiftId)
        {
            return context.Bookings
                .Include(p => p.Pet)
                .Include(d => d.Doctor)
                .Include(s => s.Schedule)
                .Include(s => s.Service)
                .FirstOrDefault(b => b.PetId == petId && b.Schedule.Date == date && b.Schedule.ShiftId == shiftId && b.BookingStatus == (int)BookingStatus.Pending)!;
        }

        public List<Booking> GetBookingListByDateAndShiftId(DateTime date, int shiftId)
        {
            return context.Bookings
                .Include(p => p.Pet)
                .Include(d => d.Doctor)
                .Include(s => s.Schedule)
                .Include(s => s.Service)
                .Where(b => b.Schedule.Date == date && b.Schedule.ShiftId == shiftId && b.BookingStatus == (int)BookingStatus.Pending)
                .ToList();
        }

        //public List<Booking> SearchBy(DateTime date, int shiftId, int doctorId)
        //{
        //    return context.Bookings
        //        .Include(p => p.Pet)
        //        .Include(d => d.Doctor)
        //        .Include(s => s.Schedule)
        //        .Include(s => s.Service)
        //        .Where(b => b.Schedule.Date == date || b.Schedule.ShiftId == shiftId && b.DoctorId == doctorId)
        //        .ToList();
        //}

        //public List<Booking> FilterByCustomerName(string customerName)
        //{
        //    return context.Bookings
        //        .Include(p => p.Pet)
        //        .Include(c => c.Pet.Customer)
        //        .Include(d => d.Doctor)
        //        .Include(s => s.Schedule)
        //        .Include(s => s.Service)
        //        .Where(b => b.Pet.Customer.FirstName.Contains(customerName))
        //        .ToList();
        //}

        //public List<Booking> FilterByDoctorId(int doctorId)
        //{
        //    return context.Bookings
        //        .Include(p => p.Pet)
        //        .Include(c => c.Pet.Customer)
        //        .Include(d => d.Doctor)
        //        .Include(s => s.Schedule)
        //        .Include(s => s.Service)
        //        .Where(b => b.DoctorId == doctorId)
        //        .ToList();
        //}
        //public List<Booking> FilterByServiceId(int serviceId)
        //{
        //    return context.Bookings
        //        .Include(p => p.Pet)
        //        .Include(c => c.Pet.Customer)
        //        .Include(d => d.Doctor)
        //        .Include(s => s.Schedule)
        //        .Include(s => s.Service)
        //        .Where(b => b.ServiceId == serviceId)
        //        .ToList();
        //}

        //public List<>
    }
}
