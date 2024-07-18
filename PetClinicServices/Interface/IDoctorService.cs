﻿using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IDoctorService
    {
        public List<User> GetAllDoctors();
        public User GetDoctorById(int doctorId);
        public void UpdateDoctor(User doctor);
    }
}
