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
    public class CageService : ICageService
    {
        private readonly ICageRepository cageRepository;

        public CageService()
        {
            if(cageRepository == null)
            {
                cageRepository = new CageRepository();
            }
        }

        public List<Cage> GetAll()
        {
            return cageRepository.GetAll();
        }

        public Cage? GetCageById(int id)
        {
            return cageRepository.GetCageById(id);
        }

        public void Add(Cage cage)
        {
            cageRepository.Add(cage);
        }

        public void Update(Cage cage)
        {
            cageRepository.Update(cage);
        }
    }
}
