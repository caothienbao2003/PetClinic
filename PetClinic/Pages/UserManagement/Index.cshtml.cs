using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.UserManagement
{
    public class IndexModel : PageModel
    {
        private readonly IUserSerivce userSerivce;

		public IndexModel(IUserSerivce _userSerivce)
        {
            userSerivce = _userSerivce;
		}

        public List<User> userList { get;set; } = default!;

        public void OnGet()
        {
            if (userList != null)
            {
				userList = userSerivce.GetAllUsers();
            }
        }
    }
}
