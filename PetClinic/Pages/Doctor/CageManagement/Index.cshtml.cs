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

namespace PetClinic.Pages.Doctor.CageManagement
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
            Cage = cageService.GetAllCage()
                .OrderByDescending(c => c.ActiveStatus == (int)ActiveStatus.Active)
                .ThenByDescending(c => c.CageStatus == (int)CageStatus.Occupied)
                .ThenBy(c => c.CageId)
                .ToList();
        }

        public IActionResult OnPostToggleActiveStatus(int cageId, int currentStatus)
        {
            var cage = cageService.GetCageById(cageId);
            if (cage == null)
            {
                return NotFound();
            }

            cage.ActiveStatus = currentStatus == (int)ActiveStatus.UnActive ? (int)ActiveStatus.Active : (int)ActiveStatus.UnActive;
            cageService.UpdateCage(cage);

            return RedirectToPage();
        }
    }
}
