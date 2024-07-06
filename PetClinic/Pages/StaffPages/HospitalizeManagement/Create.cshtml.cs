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

        [BindProperty(SupportsGet = true)]
        public int? CageId { get; set; }

        public IActionResult OnGet(int? cageId)
        {

            ViewData["DoctorId"] = new SelectList(userSerivce.GetAllUsers(), "UserId", "Username");
            ViewData["PetId"] = new SelectList(petService.GetAll(), "PetId", "PetName");

            if (cageId.HasValue)
            {
                CageId = cageId;
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

            Hospitalize.InTime = DateTime.Now;

            hospitalizeService.AddHospitalize(Hospitalize);

            var hospitalizeFromDb = hospitalizeService.GetHospitalizeById(Hospitalize.HospitalizeId);
            if (hospitalizeFromDb == null || !hospitalizeFromDb.CageId.HasValue)
            {
                // Handle the case where the Hospitalize or CageId is null
                ModelState.AddModelError(string.Empty, "Unable to find hospitalize record or cage.");
                return Page();
            }

            var cage = cageService.GetCageById(hospitalizeFromDb.CageId.Value);

            if (cage != null)
            {
                cage.CageEnumStatus = CageStatus.Occupied;
                cage.ActiveEnumStatus = ActiveStatus.Active;
                cageService.UpdateCage(cage);
            }

            return RedirectToPage("/StaffPages/CageManagement/Index");
        }
    }
}
