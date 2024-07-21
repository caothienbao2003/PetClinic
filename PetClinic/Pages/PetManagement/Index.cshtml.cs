using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.PetManagement
{
    public class IndexModel : PageModel
    {
        private readonly IPetService petService;

        public IndexModel(IPetService _petService)
        {
            petService = _petService;
        }

        public List<Pet> petList { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchPetName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCustomer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchPetType { get; set; }

        public void OnGet()
        {
            var query = petService.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(SearchPetName))
            {
                query = query.Where(p => p.PetName.Contains(SearchPetName));
            }

            if (!string.IsNullOrEmpty(SearchCustomer))
            {
                query = query.Where(p => p.Customer.FirstName.Contains(SearchCustomer));
            }

            if (!string.IsNullOrEmpty(SearchPetType) && SearchPetType != "All")
            {
                query = query.Where(p => p.PetType == SearchPetType);
            }

            petList = query.ToList();
        }
    }
}
