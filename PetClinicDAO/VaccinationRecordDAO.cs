using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetClinicDAO
{
    public class VaccinationRecordDAO
    {
        private readonly PetClinicContext context;

        private static VaccinationRecordDAO? instance;

        public VaccinationRecordDAO()
        {
            context = new PetClinicContext();
        }

        public static VaccinationRecordDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccinationRecordDAO();
                }
                return instance;
            }
        }

        public List<VaccinationRecord> GetVaccinationRecordsList()
        {
            return context.VaccinationRecords.ToList();
        }

        public VaccinationRecord GetVaccinationRecordById(int id)
        {
            return context.VaccinationRecords.FirstOrDefault(v => v.VaccinationRecordId == id)!;
        }

        public List<VaccinationRecord> GetVaccinationRecordsByPetHealthId(int petHealthId)
        {
            return context.VaccinationRecords.Where(v => v.PetHealthId == petHealthId).ToList();
        }

        public void AddVaccinationRecord(VaccinationRecord vaccinationRecord)
        {
            context.VaccinationRecords.Add(vaccinationRecord);
            context.SaveChanges();
        }

        public void UpdateVaccinationRecord(VaccinationRecord vaccinationRecord)
        {
            context.VaccinationRecords.Update(vaccinationRecord);
            context.SaveChanges();
        }

    }
}
