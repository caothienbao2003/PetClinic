using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService()
        {
            if (bookingRepository == null)
            {
                bookingRepository = new BookingRepository();
            }
        }

        public void AddBooking(Booking booking) => bookingRepository.Add(booking);
        public Booking? GetBookingById(int id) => bookingRepository.GetBookingById(id);
        public List<Booking> GetAll() => bookingRepository.GetAll();
        public List<Booking> GetBookingListByPetId(int petId) => bookingRepository.GetBookingListByPetId(petId);
        public List<Booking> GetBookingListByUserId(int userId) => bookingRepository.GetBookingByUserId(userId);
        public void UpdateBooking(Booking booking) => bookingRepository.Update(booking);
        public Booking GetBooking(int petId, int scheduleId) => bookingRepository.GetBooking(petId, scheduleId);
        public List<Booking> SearchBy(DateTime? startDate, DateTime? endDate, int? paymentStatus, int? bookingStatus, int? shiftId, string doctorName, string customerName, string petName)
        {
            var bookings = bookingRepository.GetAll().AsQueryable();

            if (startDate.HasValue && endDate.HasValue)
            {
                bookings = bookings.Where(b => b.Schedule.Date >= startDate.Value.Date && b.Schedule.Date <= endDate.Value.Date);
            }
            else if (startDate.HasValue)
            {
                bookings = bookings.Where(b => b.Schedule.Date >= startDate.Value.Date);
            }
            else if (endDate.HasValue)
            {
                bookings = bookings.Where(b => b.Schedule.Date <= endDate.Value.Date);
            }

            if (paymentStatus.HasValue)
            {
                bookings = bookings.Where(b => b.PaymentStatus == paymentStatus);
            }

            if (bookingStatus.HasValue)
            {
                bookings = bookings.Where(b => b.BookingStatus == bookingStatus);
            }

            if (shiftId.HasValue)
            {
                bookings = bookings.Where(b => b.Schedule.ShiftId == shiftId.Value);
            }

            if (!string.IsNullOrEmpty(doctorName))
            {
                bookings = bookings.Where(b => b.Doctor.FirstName.Contains(doctorName) || b.Doctor.LastName.Contains(doctorName));
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                bookings = bookings.Where(b => b.Pet.Customer.FirstName.Contains(customerName) || b.Pet.Customer.LastName.Contains(customerName));
            }

            if (!string.IsNullOrEmpty(petName))
            {
                bookings = bookings.Where(b => b.Pet.PetName.Contains(petName));
            }

            return bookings.ToList();
        }
        public Booking GetExistedBookingList(int petId, DateTime date, int shiftId) => bookingRepository.GetExistedBookingList(petId, date, shiftId);
        public List<Booking> GetBookingListByDateAndShiftId(DateTime date, int shiftId) => bookingRepository.GetBookingListByDateAndShiftId(date, shiftId);
        public int GetNoOfOccupationByDateAndShiftId(DateTime date, int shiftId)
        {
            List<Booking> bookingList = GetBookingListByDateAndShiftId(date, shiftId);
            return bookingList.Count;
        }
    }
}
