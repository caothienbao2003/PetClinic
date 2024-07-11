using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IPetService
    {
        public List<Pet> GetAll();

        public List<Pet> GetPetListByUserId(int userId);

        public Pet GetPetById(int petId);

        public List<PetHealth> GetPetHealthsList();

        public PetHealth GetPetHealthByPetId(int petId);

        public void AddPet(Pet pet);

        public void AddPetToUserId(Pet pet, int userId);

        public void RemovePet(int petId);

        public void UpdatePet(Pet pet);

        public void UpdatePetHealth(PetHealth petHealth);
    }
}
