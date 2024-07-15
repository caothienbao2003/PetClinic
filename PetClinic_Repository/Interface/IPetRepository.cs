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
        public List<PetHealth> GetPetHealthsList();
        public PetHealth GetPetHealthByPetId(int? petId);
        public void RemovePet(int petId);
        public void AddPet(Pet pet);
        public void UpdatePet(Pet pet);
        public void UpdatePetHealth(PetHealth petHealth);
        public List<VaccinationRecord> GetVaccinationsByPetHealthId(int petHealthId);
    }
}
