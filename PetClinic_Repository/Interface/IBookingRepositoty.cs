﻿using PetClinicBussinessObject;
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
		public void Add(Booking booking);
	}
}