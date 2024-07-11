using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IMedicalRecordRepository
    {
        public List<MedicalRecord> GetMedicalRecordsList();

        public MedicalRecord GetMedicalRecordByBookingId(int id);

        public void AddMedicalRecord(MedicalRecord medicalRecord);

        public List<Service> GetServices();

    }
}
