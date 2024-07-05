using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class HospitalizeDAO
    {
        private readonly PetClinicContext context;

        private static HospitalizeDAO? instance;

        public HospitalizeDAO()
        {
            context = new PetClinicContext();
        }

        public static HospitalizeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HospitalizeDAO();
                }
                return instance;
            }
        }

        public List<Hospitalize> GetAllHospitalize()
        {
            return context.Hospitalizes.ToList();
        }

        public Hospitalize? GetHospitalizeById(int id)
        {
            return context.Hospitalizes.Find(id);
        }

        public void AddHospitalize(Hospitalize hospitalize)
        {
            if (GetHospitalizeById(hospitalize.HospitalizeId) != null)
            {
                return;
            }

            context.Hospitalizes.Add(hospitalize);
            context.SaveChanges();
        }

        public void UpdateHospitalize(Hospitalize hospitalize)
        {
            if (GetHospitalizeById(hospitalize.HospitalizeId) == null)
            {
                return;
            }

            context.Hospitalizes.Update(hospitalize);
            context.SaveChanges();
        }
    }
}
