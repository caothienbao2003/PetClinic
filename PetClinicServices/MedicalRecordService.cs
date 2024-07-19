using PetClinicBussinessObject;
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
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository medicalRecordRepository; 

        public MedicalRecordService()
        {
            if(medicalRecordRepository == null)
            {
                medicalRecordRepository = new MedicalRecordRepository();
            }
        }

        public List<MedicalRecord> GetMedicalRecordsList()
        {
            return medicalRecordRepository.GetMedicalRecordsList();
        }

        public MedicalRecord GetMedicalRecordByBookingId(int id)
        {
            return medicalRecordRepository.GetMedicalRecordByBookingId(id);
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return medicalRecordRepository.GetMedicalRecordById(id);
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            medicalRecordRepository.AddMedicalRecord(medicalRecord);
        }

        public List<Service> GetServices()
        {
            return medicalRecordRepository.GetServices();
        }
    }
}
