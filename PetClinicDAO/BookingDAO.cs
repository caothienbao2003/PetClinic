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
    }
}
