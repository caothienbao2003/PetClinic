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
    }
}
