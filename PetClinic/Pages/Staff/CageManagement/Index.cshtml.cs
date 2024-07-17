using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.CageManagement
{
    public class IndexModel : PageModel
    {
        private readonly ICageService cageService;

        public IndexModel(ICageService _cageService)
        {
            cageService = _cageService;
        }

        public List<Cage> Cage { get;set; } = default!;

        public void OnGet()
        {
            Cage = cageService.GetAllCage();
        }
    }
}
