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
        public List<Cage> GetAll();
        public Cage? GetCageById(int id);
        public void Add(Cage cage);
        public void Update(Cage cage);
    }
}
