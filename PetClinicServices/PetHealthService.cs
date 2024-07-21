using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicServices.Interface;
using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;

namespace PetClinicServices
{
    public class PetHealthService : IPetHealthService
    {
        private readonly IPetHealthRepository petHealthRepository;

        public PetHealthService()
        {
            if (petHealthRepository == null)
            {
                petHealthRepository = new PetHealthRepository();
            }
        }

        public List<PetHealth> GetAllPetHealths()
        {
            return petHealthRepository.GetAllPetHealths();
        }

        public PetHealth GetPetHealthByPetId(int petId)
        {
            return petHealthRepository.GetPetHealthByPetId(petId);
        }

        public PetHealth GetPetHealthById(int petHealthId)
        {
            return petHealthRepository.GetPetHealthById(petHealthId);
        }

        public void AddPetHealth(PetHealth petHealth)
        {
            petHealthRepository.AddPetHealth(petHealth);
        }

        public void UpdatePetHealth(PetHealth petHealth)
        {
            petHealthRepository.UpdatePetHealth(petHealth);
        }
    }
}
