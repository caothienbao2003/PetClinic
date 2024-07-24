using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.PetManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IUserService userService;
        private readonly IPetService petService;
        private readonly IVaccinationRecordService vaccinationRecordService;
        private readonly IMedicineService medicineService;

        public DetailsModel(IMedicalRecordService _medicalRecordService, IUserService _userService,
            IPetService _petService, IVaccinationRecordService _vaccinationRecordService, IMedicineService _medicineService)
        {
            medicalRecordService = _medicalRecordService;
            userService = _userService;
            petService = _petService;
            vaccinationRecordService = _vaccinationRecordService;
            medicineService = _medicineService;
        }

        [BindProperty]
        public User user { get; set; } = default!;

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty]
        public PetHealth? PetHealth { get; set; } = default!;

        [BindProperty]
        public List<VaccinationRecord>? VaccinationRecordList { get; set; } = default!;

        [BindProperty]
        public List<Medicine> MedicineList { get; set; } = new List<Medicine>();

        [BindProperty]
        public VaccinationRecord NewVaccinationRecord { get; set; }

        public List<VaccinationRecordViewModel> VaccinationRecordViewModelList { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int PetId { get; set; }

        public IActionResult OnGet(int id)
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }

            PetId = id;

            var pet = petService.GetPetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            Pet = pet;

            PetHealth = petService.GetPetHealthByPetId(Pet.PetId);

            if (PetHealth == null)
            {
                PetHealth = new PetHealth();
            }

            VaccinationRecordList = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(PetHealth.PetHealthId);

            MedicineList = medicineService.GetMedicineList();

            return Page();
        }

        public IActionResult OnPostAddVaccination()
        {
            if (NewVaccinationRecord != null)
            {
                NewVaccinationRecord.Verification = NewVaccinationRecord.Verification;

                vaccinationRecordService.AddVaccinationRecord(NewVaccinationRecord);
            }

            var updatedRecords = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(NewVaccinationRecord!.PetHealthId!.Value);
            return new JsonResult(updatedRecords);
        }
    }
}