using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        public List<MedicalRecord> GetMedicalRecordsList() => MedicalRecordDAO.Instance.GetMedicalRecordsList();

        public MedicalRecord GetMedicalRecordByBookingId(int id) => MedicalRecordDAO.Instance.GetMedicalRecordByBookingId(id);

        public MedicalRecord GetMedicalRecordById(int id) => MedicalRecordDAO.Instance.GetMedicalRecordById(id);

        public void AddMedicalRecord(MedicalRecord medicalRecord) => MedicalRecordDAO.Instance.AddMedicalRecord(medicalRecord);

        public List<Service> GetServices() => MedicalRecordDAO.Instance.GetServices();
    }
}
