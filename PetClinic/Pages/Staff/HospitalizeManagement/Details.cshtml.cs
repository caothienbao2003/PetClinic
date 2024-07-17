using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.HospitializeManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;

        public DetailsModel(IHospitalizeService _hospitalizeService)
        {
            hospitalizeService = _hospitalizeService;
        }

        public Hospitalize Hospitalize { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitalize = hospitalizeService.GetHospitalizeById(id.Value);
            if (hospitalize == null)
            {
                return NotFound();
            }
            else
            {
                Hospitalize = hospitalize;
            }
            return Page();
        }
    }
}
