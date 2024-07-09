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
    }
}
