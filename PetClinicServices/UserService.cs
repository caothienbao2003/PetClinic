using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            if(userRepository == null)
            {
                userRepository = new UserRepository();
            }
        }

		public List<User> GetAllUsers()
		{
			return userRepository.GetAllUsers();
		}

		public User GetUser(string email, string password)
        {
            return userRepository.GetUser(email, password);
        }

        public User GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public async Task<User> AddUser(User newUser)
        {
            userRepository.AddUser(newUser);
            return newUser;
        }

		public bool IsAdmin(User user)
		{
			return userRepository.IsAdmin(user);
		}
	}
}
