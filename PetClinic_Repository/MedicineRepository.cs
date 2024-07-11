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
    }
}
