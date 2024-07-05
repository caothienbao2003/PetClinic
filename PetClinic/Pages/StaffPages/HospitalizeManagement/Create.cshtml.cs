using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.HospitializeManagement
{
    public class CreateModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly IUserSerivce userSerivce;
        private readonly ICageService cageService;
        private readonly IPetService petService;

        public CreateModel(IHospitalizeService _hospitalizeService, IUserSerivce _userSerivce, ICageService _cageService, IPetService _petService)
        {
            hospitalizeService = _hospitalizeService;
            userSerivce = _userSerivce;
            cageService = _cageService;
            petService = _petService;
        }

        public IActionResult OnGet(int? cageId)
        {
            ViewData["CageId"] = new SelectList(cageService.GetAllCage(), "CageId", "CageId");
            ViewData["DoctorId"] = new SelectList(userSerivce.GetAllUsers(), "UserId", "Username");
            ViewData["PetId"] = new SelectList(petService.GetAll(), "PetId", "PetName");

            if (cageId.HasValue)
            {
                Hospitalize = new Hospitalize { CageId = cageId.Value };
            }

            return Page();
        }

        [BindProperty]
        public Hospitalize Hospitalize { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            hospitalizeService.AddHospitalize(Hospitalize);

            var cage = cageService.GetCageById(hospitalizeService.GetHospitalizeById(Hospitalize.HospitalizeId).CageId.Value);

            if (cage != null)
            {
                cage.Status = 1;
                cageService.UpdateCage(cage);
            }

            return RedirectToPage("./Index");
        }
    }
}
