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

        private static BookingDAO instance;

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

        public List<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public Booking? GetBookingById(int id)
		{
			return context.Bookings.Find(id);
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
