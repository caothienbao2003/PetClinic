using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;

namespace PetClinicRepository
{
    public class MedicineRepository : IMedicineRepository
    {
        public List<Medicine> GetMedicineList() => MedicineDAO.Instance.GetMedicineList();

        public Medicine GetMedicineById(int medicineId) => MedicineDAO.Instance.GetMedicineById(medicineId);

        public void AddMedicine(Medicine medicine) => MedicineDAO.Instance.AddMedicine(medicine);

        public void UpdateMedicine(Medicine medicine) => MedicineDAO.Instance.UpdateMedicine(medicine);

        public void RemoveMedicine(int medicineId) => MedicineDAO.Instance.RemoveMedicine(medicineId);
    }
}
