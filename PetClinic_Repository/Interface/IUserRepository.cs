using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IUserRepository
    {
        public User GetUser(string email, string password);

        public List<User> GetAllUsers();
        public User GetUserById(int id);
	}
}
