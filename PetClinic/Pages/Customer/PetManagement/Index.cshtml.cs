using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class IndexModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IUserService userService;

        public IndexModel(IPetService _petService, IUserService _userService)
        {
            petService = _petService;
            userService = _userService;
        }

        public List<Pet> petList { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchPetName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchPetType { get; set; }

        [BindProperty]
        public User user { get; set; } = default!;

        public void OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
                petList = new List<Pet>();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }

            var query = petService.GetAll().Where(p => p.CustomerId == user.UserId).AsQueryable();

            if (!string.IsNullOrEmpty(SearchPetName))
            {
                query = query.Where(p => p.PetName.Contains(SearchPetName));
            }

            if (!string.IsNullOrEmpty(SearchPetType) && SearchPetType != "All")
            {
                query = query.Where(p => p.PetType == SearchPetType);
            }

            petList = query.ToList();
        }
    }
}
