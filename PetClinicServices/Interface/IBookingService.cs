﻿using PetClinicBussinessObject;
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
        public Booking GetBookingList(int petId, int scheduleId);
        public List<Booking> SearchBy(DateTime? startDate, DateTime? endDate, int? paymentStatus, int? bookingStatus, int? shiftId, string doctorName, string customerName, string petName);
    }
}
