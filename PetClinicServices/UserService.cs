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
    public class UserService : IUserSerivce
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            if(userRepository == null)
            {
                userRepository = new UserRepository();
            }
        }
        public User GetUser(string userName, string password)
        {
            return userRepository.GetUser(userName, password);
        }
    }
}
