using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;

        public PetService()
        {
            if (petRepository == null)
            {
                petRepository = new PetRepository();
            }
        }

        public List<Pet> GetAll()
        {
            return petRepository.GetAll();
        }

        public List<Pet> GetPetListByUserId(int userId)
        {
            return petRepository.GetPetListByUserId(userId);
        }

        public Pet GetPetById(int petId)
        {
            return petRepository.GetPetById(petId);
        }

        public List<PetHealth> GetPetHealthsList()
        {
            return petRepository.GetPetHealthsList();
        }

        public PetHealth GetPetHealthByPetId(int petId)
        {
            return petRepository.GetPetHealthByPetId(petId);
        }

        public void AddPet(Pet pet)
        {
            petRepository.AddPet(pet);
        }

        public void AddPetToUserId(Pet pet, int userId)
        {
            petRepository.AddPetToUserId(pet, userId);
        }

        public void RemovePet(int petId)
        {
            petRepository.RemovePet(petId);
        }

        public void UpdatePet(Pet pet)
        {
            petRepository.UpdatePet(pet);
        }

        public void UpdatePetHealth(PetHealth petHealth)
        {
            petRepository.UpdatePetHealth(petHealth);
        }
    }
}
