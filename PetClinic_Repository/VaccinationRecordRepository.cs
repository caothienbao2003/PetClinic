using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicRepository.Interface;
using PetClinicDAO;

namespace PetClinicRepository
{
    public class VaccinationRecordRepository : IVaccinationRecordRepository
    {
        public List<VaccinationRecord> GetVaccinationRecordsList() => VaccinationRecordDAO.Instance.GetVaccinationRecordsList();

        public VaccinationRecord GetVaccinationRecordById(int id) => VaccinationRecordDAO.Instance.GetVaccinationRecordById(id);

        public List<VaccinationRecord> GetVaccinationRecordsByPetHealthId(int petHealthId) => VaccinationRecordDAO.Instance.GetVaccinationRecordsByPetHealthId(petHealthId);

    }
}
