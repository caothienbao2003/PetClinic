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
        public List<Cage> GetAllCage() => CageDAO.Instance.GetAllCage();

        public Cage? GetCageById(int id) => CageDAO.Instance.GetCageById(id);

        public void AddCage(Cage cage) => CageDAO.Instance.AddCage(cage);

        public void UpdateCage(Cage cage) => CageDAO.Instance.UpdateCage(cage);
    }
}
