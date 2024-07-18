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
    public class DoctorRepository : IDoctorRepository
    {
        public List<User> GetAllDoctors() => UserDAO.Instance.GetUserListWithRole(UserRole.Doctor);
        public User GetDoctorById(int id) => UserDAO.Instance.GetUserByIdAndRole(id, UserRole.Doctor);
        public void UpdateDoctor(User doctor) => UserDAO.Instance.UpdateUser(doctor);
    }
}
