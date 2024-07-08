﻿using PetClinicBussinessObject;
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

		public User GetUser(string email, string password) => UserDAO.Instance.GetUser(email, password);
	
        public User GetUserById(int id) => UserDAO.Instance.GetUserById(id);

        public void AddUser(User newUser) => UserDAO.Instance.AddUser(newUser);

        public bool IsAdmin(User user) => UserDAO.Instance.IsAdmin(user);

        public User GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);


    }
}
