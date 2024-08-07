﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicRepository.Interface
{
    public interface IVaccinationRecordRepository
    {
        public List<VaccinationRecord> GetVaccinationRecordsList();
        public VaccinationRecord GetVaccinationRecordById(int id);
        public List<VaccinationRecord> GetVaccinationRecordsByPetHealthId(int petHealthId);
        public void AddVaccinationRecord(VaccinationRecord vaccinationRecord);
        public void UpdateVaccinationRecord(VaccinationRecord vaccinationRecord);
        public void DeleteVaccinationRecord(int id);
    }
}
