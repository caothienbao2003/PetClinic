using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.PetHealthManagement
{
    public class IndexModel : PageModel
    {
        private readonly IPetService petService;

        public IndexModel(IPetService _petService)
        {
            petService = _petService;
        }

        public List<PetHealth> petHealthList { get; set; } = default!;

        public void OnGet()
        {
            petHealthList = petService.GetPetHealthsList();
        }
    }
}
