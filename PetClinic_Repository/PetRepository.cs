using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class PetRepository : IPetRepository
    {
        public List<Pet> GetAll() => PetDAO.Instance.GetAll();

        public List<Pet> GetPetListByUserId(int userId) => PetDAO.Instance.GetPetListByUserId(userId);

        public Pet GetPetById(int petId) => PetDAO.Instance.GetPetById(petId);

        public List<PetHealth> GetPetHealthsList() => PetDAO.Instance.GetPetHealthsList();

        public PetHealth GetPetHealthByPetId(int petId) => PetDAO.Instance.GetPetHealthByPetId(petId);

        public void AddPet(Pet pet) => PetDAO.Instance.AddPet(pet);

        public void AddPetToUserId(Pet pet, int userId) => PetDAO.Instance.AddPetToUserId(pet, userId);

        public void RemovePet(int petId) => PetDAO.Instance.RemovePet(petId);

        public void UpdatePet(Pet pet) => PetDAO.Instance.UpdatePet(pet);

        public void UpdatePetHealth(PetHealth petHealth) => PetDAO.Instance.UpdatePetHealth(petHealth);
    }
}
