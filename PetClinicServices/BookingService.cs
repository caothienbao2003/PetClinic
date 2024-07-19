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
    }
}
