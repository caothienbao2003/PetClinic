using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class EditModel : PageModel
    {
        private readonly ICageService cageService;

        public EditModel(ICageService _cageService)
        {
            cageService = _cageService;
        }

        [BindProperty]
        public Cage Cage { get; set; } = default!;

        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
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
            Cage = cage;

            StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Available", Text = "Available" },
                new SelectListItem { Value = "Occupied", Text = "Occupied" }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var existingCage = cageService.GetCageById(Cage.CageId);
                if (existingCage != null)
                {
                    existingCage.Status = Cage.Status;
                    existingCage.ActiveStatus = Cage.ActiveStatus;
                    cageService.Update(existingCage);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CageExists(Cage.CageId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CageExists(int id)
        {
            return cageService.GetCageById(id) != null;
        }


    }
}
