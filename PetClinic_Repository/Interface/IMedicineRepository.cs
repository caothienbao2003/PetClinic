using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicRepository.Interface
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetMedicineList();
    }
}
