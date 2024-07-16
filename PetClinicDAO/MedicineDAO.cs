using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using Microsoft.EntityFrameworkCore;

namespace PetClinicDAO
{
    public class MedicineDAO
    {
        private readonly PetClinicContext context;

        private static MedicineDAO? instance;

        public MedicineDAO()
        {
            context = new PetClinicContext();
        }

        public static MedicineDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicineDAO();
                }
                return instance;
            }
        }

        public List<Medicine> GetMedicineList()
        {
            return context.Medicines.ToList();
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);
        }

        public void AddMedicine(Medicine medicine)
        {
            context.Medicines.Add(medicine);
            context.SaveChanges();
        }

        public void UpdateMedicine(Medicine medicine)
        {
            context.Medicines.Update(medicine);
            context.SaveChanges();
        }

        public void RemoveMedicine(int medicineId)
        {
            var medicine = context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);
            if(medicine != null)
            {
                medicine.ActiveStatus = (int)ActiveStatus.UnActive; 
                context.SaveChanges();
            }
        }
    }
}
