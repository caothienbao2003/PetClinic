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
            return context.VaccinationRecords.Include(v => v.VaccinationRecordsId).Include(v => v.VaccinationDetailsId).Include(v => v.VaccinationDetails).ToList();
        }

        public VaccinationRecord GetVaccinationRecordByVaccinationRecordsId(int id)
        {
            return context.VaccinationRecords.Include(v => v.VaccinationRecordsId).Include(v => v.VaccinationDetailsId).Include(v => v.VaccinationDetails).FirstOrDefault(v => v.VaccinationRecordsId == id)!;
        }

        public void UpdateVaccinationDetails(VaccinationDetail vaccinationDetail)
        {
            if (GetVaccinationRecordByVaccinationRecordsId(vaccinationDetail.VaccinationDetailsId) == null)
            {
                return;
            }
            context.VaccinationDetails.Update(vaccinationDetail);
            context.SaveChanges();
        }
    }
}
