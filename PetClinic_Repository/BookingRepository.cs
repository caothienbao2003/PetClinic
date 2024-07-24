﻿using PetClinicBussinessObject;
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
        public List<Booking> GetAll() => BookingDAO.Instance.GetAllBooking();
        public Booking? GetBookingById(int id) => BookingDAO.Instance.GetBookingById(id);
        public void Add(Booking booking) => BookingDAO.Instance.Add(booking);
        public List<Booking> GetBookingListByPetId(int petId) => BookingDAO.Instance.GetAllBooking().Where(x => x.PetId == petId).ToList();
        public List<Booking> GetBookingByUserId(int userId) => BookingDAO.Instance.GetAllBooking().Where(x => x.Pet.CustomerId == userId).ToList();
        public void Update(Booking booking) => BookingDAO.Instance.Update(booking);
        public Booking GetBooking(int petId, int scheduleId) => BookingDAO.Instance.GetBooking(petId, scheduleId);
        public Booking GetExistedBookingList(int petId, DateTime date, int shiftId) => BookingDAO.Instance.GetExistedBookingList(petId, date, shiftId);
        public List<Booking> GetBookingListByDateAndShiftId(DateTime date, int shiftId) => BookingDAO.Instance.GetBookingListByDateAndShiftId(date, shiftId);
    }
}
