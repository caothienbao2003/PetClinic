using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface ICageRepository
    {
        public List<Cage> GetAllCage();
        public Cage? GetCageById(int id);
        public void AddCage(Cage cage);
        public void UpdateCage(Cage cage);
    }
}
