using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IPetRepository
    {
        public List<Pet> GetAll();
        public List<Pet> GetPetListByUserId(int userId);
        public Pet GetPetById(int petId);
        public Pet RemovePet(int petId);
    }
}
