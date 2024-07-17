using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        public User GetUserByEmail(string email) 
        { 
            return context.Users.FirstOrDefault(u => u.Email == email)!; 
        }

        public void AddUser(User newUser)
        {
            try
            {
                context.Users.Add(newUser);
                context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add user.", ex);
            }
        }

        public bool IsAdmin(User user)
        {
			try
			{
				var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Email").Value;
				var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminCredentials:Password").Value;

				if (user.Email == adminEmail && user.Password == adminPassword)
				{
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
    
        public List<User> GetUserListWithRole(UserRole userRole)
        {
            return context.Users
                .Where(u => u.Role == (int) userRole)
                .Include(u => u.Pets)
                .ToList();
        }

        public void UpdateUser(User user)
        {
            var existingUser = context.Users.Local.FirstOrDefault(u => u.UserId == user.UserId);

            if (existingUser != null)
            {
                context.Entry(existingUser).State = EntityState.Detached;
            }

            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    } 
}
