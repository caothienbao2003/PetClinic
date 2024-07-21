using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicRepository.Interface;
using PetClinicDAO;

namespace PetClinicRepository
{
    public class PetHealthRepository : IPetHealthRepository
    {
        public List<PetHealth> GetAllPetHealths() => PetHealthDAO.Instance.GetAllPetHealths();

        public PetHealth GetPetHealthByPetId(int petId) => PetHealthDAO.Instance.GetPetHealthByPetId(petId);

        public PetHealth GetPetHealthById(int petHealthId) => PetHealthDAO.Instance.GetPetHealthById(petHealthId);

        public void AddPetHealth(PetHealth petHealth) => PetHealthDAO.Instance.AddPetHealth(petHealth);

        public void UpdatePetHealth(PetHealth petHealth) => PetHealthDAO.Instance.UpdatePetHealth(petHealth);
    }
}
