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
            return context.Bookings.Include(p => p.Pet).Include(d => d.Doctor).Include(s => s.Schedule).Include(s => s.Service).ToList();
        }

        public Booking? GetBookingById(int id)
		{
			return context.Bookings.Include(p => p.Pet).FirstOrDefault(b => b.BookingId == id);
		}

        public void Add(Booking booking)
		{
            if(GetBookingById(booking.BookingId) != null)
            {
                return;
            }

			context.Bookings.Add(booking);
			context.SaveChanges();
		}

		public void Update(Booking booking)
		{
            if(GetBookingById(booking.BookingId) == null)
            {
                return;
            }

			context.Bookings.Update(booking);
			context.SaveChanges();
		}
    }
}
