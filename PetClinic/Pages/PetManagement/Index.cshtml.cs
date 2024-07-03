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

        //public async Task OnGetAsync()
        //{
        //    if (petList != null)
        //    {
        //        petList = petService.GetAll();
        //    }
        //}

        public void OnGet()
        {
            petList = petService.GetAll();
        }

    }
}
