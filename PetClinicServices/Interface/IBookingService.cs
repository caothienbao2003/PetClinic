using PetClinicBussinessObject;
using PetClinicDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IBookingService
    {
        public List<Booking> GetAll();
        public Booking? GetBookingById(int id);
        public void AddBooking(Booking booking);
        public List<Booking> GetBookingListByPetId(int petId);
        public List<Booking> GetBookingListByUserId(int userId);
        public void UpdateBooking(Booking booking);
    }
}
