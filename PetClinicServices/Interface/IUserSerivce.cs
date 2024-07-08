﻿using PetClinicBussinessObject;
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

        Task<User> AddUser(User newUser);

        public bool IsAdmin(User user);
    }
}
