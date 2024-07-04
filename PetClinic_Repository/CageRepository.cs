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
    public class CageRepository : ICageRepository
    {
        public List<Cage> GetAll() => CageDAO.Instance.GetAll();

        public Cage? GetCageById(int id) => CageDAO.Instance.GetCageById(id);

        public void Add(Cage cage) => CageDAO.Instance.Add(cage);


        public void Update(Cage cage) => CageDAO.Instance.Update(cage);
    }
}
