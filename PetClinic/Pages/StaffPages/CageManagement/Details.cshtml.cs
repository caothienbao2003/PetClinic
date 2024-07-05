using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class DetailsModel : PageModel
    {
        private readonly ICageService cageService;

        public DetailsModel(ICageService _cageService)
        {
            cageService = _cageService;
        }

        public Cage Cage { get; set; } = default!; 

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cage = cageService.GetCageById((int)id);

            if (cage == null)
            {
                return NotFound();
            }
            else 
            {
                Cage = cage;
            }
            return Page();
        }
    }
}
