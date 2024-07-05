using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class IndexModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;

        public IndexModel(IHospitalizeService _hospitalizeService)
        {
            hospitalizeService = _hospitalizeService;
        }

        public List<Hospitalize> Hospitalize { get; set; } = default!;

        public void OnGet()
        {
            Hospitalize = hospitalizeService.GetAllHospitalize();
                //Hospitalize = await context.Hospitalizes
                //.Include(h => h.Cage)
                //.Include(h => h.Doctor)
                //.Include(h => h.Pet).ToListAsync();
        }
    }
}
