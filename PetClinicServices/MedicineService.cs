using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;

namespace PetClinicServices
{
    public class MedicineService : IMedicineService
    {
        readonly IMedicineRepository medicineRepository;

        public MedicineService()
        {
            if(medicineRepository == null)
            {
                medicineRepository = new MedicineRepository();
            }
        }  
        public List<Medicine> GetMedicineList()
        { 
            return medicineRepository.GetMedicineList();
        }
    }
}
