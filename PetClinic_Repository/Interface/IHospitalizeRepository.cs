﻿using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IHospitalizeRepository
    {
        public List<Hospitalize> GetAllHospitalize();
        public Hospitalize? GetHospitalizeById(int id);
        public HospitalizeLog? GetLogById(int id);
        public void AddHospitalize(Hospitalize hospitalize);
        public void UpdateHospitalize(Hospitalize hospitalize);
        public List<Hospitalize> GetListByCageId(int cageId);
        public List<HospitalizeLog> GetLogListByHospitalizeId(int hospitalizeId);
        public void AddHospitalizeLog(HospitalizeLog log);
        public void UpdateHospitalizeLog(HospitalizeLog log);
        public List<Hospitalize> GetHospitalizeByPetId(int petId);
    }
}
