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
            if(petRepository == null)
            {
                petRepository = new PetRepository();
            }
        }

        public List<Pet> GetAll()
        {
            return petRepository.GetAll();
        }
    }
}
