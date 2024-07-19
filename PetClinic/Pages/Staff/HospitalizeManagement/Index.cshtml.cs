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
    public class IndexModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly ICageService cageService;

        public IndexModel(IHospitalizeService _hospitalizeService, ICageService _cageService)
        {
            hospitalizeService = _hospitalizeService;
            cageService = _cageService;
        }

        public List<Hospitalize> Hospitalize { get; set; } = default!;
        public Hospitalize hospitalize { get; set; } = default!;

        public IActionResult OnGet()
        {
            Hospitalize = hospitalizeService.GetAllHospitalize();
            return Page();
        }

        public IActionResult OnPost(int HospitalizeId)
        {
            var hospitalizeFromDb = hospitalizeService.GetHospitalizeById(HospitalizeId);
            if (hospitalizeFromDb != null)
            {
                hospitalizeFromDb.OutTime = DateTime.Now;
                hospitalizeService.UpdateHospitalize(hospitalizeFromDb);

                var cage = cageService.GetCageById(hospitalizeFromDb.CageId!.Value);
                if (cage != null)
                {
                    cage.CageStatus = (int)CageStatus.Available;
                    cageService.UpdateCage(cage);
                }
            }

            return RedirectToPage();
        }
    }
}
