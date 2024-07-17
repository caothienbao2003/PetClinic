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

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class EditModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly IUserService userSerivce;
        private readonly ICageService cageService;
        private readonly IPetService petService;

        public EditModel(IHospitalizeService _hospitalizeService, IUserService _userSerivce, ICageService _cageService, IPetService _petService)
        {
            hospitalizeService = _hospitalizeService;
            userSerivce = _userSerivce;
            cageService = _cageService;
            petService = _petService;
        }

        [BindProperty]
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
            Hospitalize = hospitalize;
            ViewData["CageId"] = new SelectList(cageService.GetAllCage(), "CageId", "CageId");
            ViewData["DoctorId"] = new SelectList(userSerivce.GetAllUsers(), "UserId", "Username");
            ViewData["PetId"] = new SelectList(petService.GetAll(), "PetId", "PetName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                var existingHospitalize = hospitalizeService.GetHospitalizeById(Hospitalize.HospitalizeId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalizeExists(Hospitalize.HospitalizeId))
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

        private bool HospitalizeExists(int id)
        {
            return (hospitalizeService.GetHospitalizeById(id)) != null;
        }
    }
}
