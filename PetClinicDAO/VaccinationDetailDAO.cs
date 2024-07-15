using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetClinicDAO
{
    public class VaccinationDetailDAO
    {
        private readonly PetClinicContext context;

        private static VaccinationDetailDAO? instance;

        public VaccinationDetailDAO()
        {
            context = new PetClinicContext();
        }

        public static VaccinationDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VaccinationDetailDAO();
                }
                return instance;
            }
        }

        public List<VaccinationDetail> GetVaccinationDetailsList() => context.VaccinationDetails.ToList();

        public VaccinationDetail GetVaccinationDetailsById(int id)
        {
            return context.VaccinationDetails.Find(id);
        }

        public void UpdateVaccinationDetails(VaccinationDetail vaccinationDetail)
        {
            context.VaccinationDetails.Update(vaccinationDetail);
            context.SaveChanges();
        }
    }
}
