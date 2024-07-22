using PetClinicBussinessObject;
using PetClinicDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IBookingRepository
    {
        public List<Booking> GetAll();
        public Booking? GetBookingById(int id);
        public void Add(Booking booking);
        public List<Booking> GetBookingListByPetId(int petId);
        public List<Booking> GetBookingByUserId(int userId);
        public void Update(Booking booking);
        public Booking GetBooking(int petId, int scheduleId);

    }
}
