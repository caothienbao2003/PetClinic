using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicServices.Interface
{
    public interface IPetHealthService
    {
        List<PetHealth> GetAllPetHealths();
        PetHealth GetPetHealthByPetId(int petId);
        PetHealth GetPetHealthById(int petHealthId);
        void AddPetHealth(PetHealth petHealth);
        void UpdatePetHealth(PetHealth petHealth);
    }
}
