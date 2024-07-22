using Microsoft.EntityFrameworkCore;
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
            return context.Hospitalizes.Include(c => c.Cage).Include(d => d.Doctor).Include(p => p.Pet).ToList();
        }

        public Hospitalize? GetHospitalizeById(int id)
        {
            return context.Hospitalizes.Find(id);
        }

        public HospitalizeLog? GetLogById(int id)
        {
            return context.HospitalizeLogs.Find(id);
        }

        public void AddHospitalize(Hospitalize hospitalize)
        {
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

        public List<Hospitalize> GetListByCageId(int id)
        {
            return context.Hospitalizes.Include(c => c.Cage).Include(d => d.Doctor).Include(p => p.Pet).Where(h => h.CageId == id).ToList();
        }

        public List<HospitalizeLog> GetLogListByHospitalizeId(int id)
        {
            return context.HospitalizeLogs.Where(h => h.HospitalizeId == id).ToList();
        }

        public void AddHospitalizeLog(HospitalizeLog log)
        {
            context.HospitalizeLogs.Add(log);
            context.SaveChanges();
        }

        public void UpdateHospitalizeLog(HospitalizeLog log)
        {
            context.HospitalizeLogs.Update(log);
            context.SaveChanges();
        }

    }
}
