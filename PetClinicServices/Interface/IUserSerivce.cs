using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IUserService
    {
        public User GetUser(string email, string password);

        public List<User> GetAllUsers();

        public User GetUserById(int id);

        public Task<User> AddUser(User newUser);

        public bool IsAdmin(User user);

        public User GetUserByEmail(string email);

		public List<User> GetUserListWithRole(UserRole userRole);

		public string GeneratePasswordResetToken(User user);

        public Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        public void UpdateUser(User user);
    }
}
