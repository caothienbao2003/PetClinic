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
    public class UserRepository : IUserRepository
    {
		public List<User> GetAllUsers() => UserDAO.Instance.GetAllUsers();

		public User GetUser(string userName, string password) => UserDAO.Instance.GetUser(userName, password);
	
        public User GetUserById(int id) => UserDAO.Instance.GetUserById(id);

	}
}
