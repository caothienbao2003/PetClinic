using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IMedicalRecordService
    {
        public List<MedicalRecord> GetMedicalRecordsList();

        public MedicalRecord GetMedicalRecordByBookingId(int id);

        public MedicalRecord GetMedicalRecordById(int id);

        public void AddMedicalRecord(MedicalRecord medicalRecord);

        public void UpdateMedicalRecord(MedicalRecord medicalRecord);

    }
}
