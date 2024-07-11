using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicServices.Interface
{
    public interface IMedicineService
    {
        public List<Medicine> GetMedicineList();
    }
}
