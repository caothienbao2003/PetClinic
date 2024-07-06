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
    public class HospitalizeRepository : IHospitalizeRepository
    {
        public List<Hospitalize> GetAllHospitalize() => HospitalizeDAO.Instance.GetAllHospitalize();

        public Hospitalize? GetHospitalizeById(int id) => HospitalizeDAO.Instance.GetHospitalizeById(id);

        public void AddHospitalize(Hospitalize hospitalize) => HospitalizeDAO.Instance.AddHospitalize(hospitalize);

        public void UpdateHospitalize(Hospitalize hospitalize) => HospitalizeDAO.Instance.UpdateHospitalize(hospitalize);
    }
}