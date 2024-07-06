using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class UserDAO
    {
        private readonly PetClinicContext context;

        private static UserDAO? instance;

        public UserDAO()
        {
            context = new PetClinicContext();
        }

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public User GetUser(string email, string password)
        {
            return context.Users.Include(p => p.Pets).FirstOrDefault(u => u.Email == email && u.Password == password)!;
        }

        public List<User> GetAllUsers() => context.Users.ToList();

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.UserId == id)!;
        }
	}
}
