﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;

namespace PetClinicServices
{
    public class VaccinationRecordService : IVaccinationRecordService
    {
        private readonly IVaccinationRecordRepository vaccinationRecordRepository;

        public VaccinationRecordService()
        {
            if (vaccinationRecordRepository == null)
            {
                vaccinationRecordRepository = new VaccinationRecordRepository();
            }
        }

        public List<VaccinationRecord> GetVaccinationRecordsList()
        {
            return vaccinationRecordRepository.GetVaccinationRecordsList();
        }

        public VaccinationRecord GetVaccinationRecordByVaccinationRecordsId(int id)
        {
            return vaccinationRecordRepository.GetVaccinationRecordByVaccinationRecordsId(id);
        }

        public void UpdateVaccinationDetail(VaccinationDetail vaccinationDetail)
        {
            vaccinationRecordRepository.UpdateVaccinationDetail(vaccinationDetail);
        }
    }
}