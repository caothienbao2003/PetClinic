using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicServices.Interface
{
    public interface IVaccinationRecordService
    {
        public List<VaccinationRecord> GetVaccinationRecordsList();

        public VaccinationRecord GetVaccinationRecordById(int id);

        public List<VaccinationRecord> GetVaccinationRecordsByPetHealthId(int petHealthId);

        public void AddVaccinationRecord(VaccinationRecord vaccinationRecord);

        public void UpdateVaccinationRecord(VaccinationRecord vaccinationRecord);
    }
}
