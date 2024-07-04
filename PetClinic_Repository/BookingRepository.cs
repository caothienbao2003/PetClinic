using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class BookingRepository : IBookingRepository
    {
        public List<Booking> GetAll() => BookingDAO.Instance.GetAll();
		public void AddBooking(int? petID, int? doctorId, int? shiftId, int? serviceId, DateTime? bookingDate)
		{
			Booking newBooking = new Booking();
			newBooking.PetId = petID;
			newBooking.DoctorId = doctorId;
			newBooking.ShiftId = shiftId;
			newBooking.ServiceId = serviceId;
			newBooking.BookingDate = bookingDate;
			newBooking.PaymentStatus = BookingPaymentStatus.Unpaid.ToString();
			newBooking.Status = BookingStatus.Pending.ToString();

			BookingDAO.Instance.Add(newBooking);
		}
	}
}
