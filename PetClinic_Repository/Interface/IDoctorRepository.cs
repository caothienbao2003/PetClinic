using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IDoctorRepository
    {
        public List<User> GetAllDoctors();
        public User GetDoctorById(int id);
    }
}
