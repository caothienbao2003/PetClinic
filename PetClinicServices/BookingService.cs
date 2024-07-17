﻿using PetClinicBussinessObject;
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
            if(bookingRepository == null)
            {
                bookingRepository = new BookingRepository();
            }
        }

        public void AddBooking(Booking booking)
        {
            bookingRepository.Add(booking);
        }

        public Booking? GetBookingById(int id)
        {
            return bookingRepository.GetBookingById(id);
        }

        public List<Booking> GetAll()
        {
            return bookingRepository.GetAll();
        }

        
    }
}
