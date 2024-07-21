using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.PetManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IPetService petService;
        private readonly IVaccinationRecordService vaccinationRecordService;
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IMedicineService medicineService;

        public DetailsModel(IPetService _petService, IVaccinationRecordService _vaccinationRecordService,
            IMedicalRecordService _medicalRecordService, IMedicineService _medicineService)
        {
            vaccinationRecordService = _vaccinationRecordService;
            petService = _petService;
            medicalRecordService = _medicalRecordService;
            medicineService = _medicineService;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        [BindProperty]
        public PetHealth PetHealth { get; set; } = default!;

        [BindProperty]
        public VaccinationRecord VaccinationRecord { get; set; } = default!;

        [BindProperty]
        public List<VaccinationRecord> VaccinationRecordList { get; set; } = default!;

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        [BindProperty]
        public List<Medicine> MedicineList { get; set; } = new List<Medicine>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetPetById(id.Value);
            var petHealth = petService.GetPetHealthByPetId(id);
            var vaccinationRecordList = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(id.Value);
            //var medicalRecord = medicalRecordService.GetMedicalRecordById(id.Value);
            var medicineList = medicineService.GetMedicineList();
            if (pet == null)
            {
                return NotFound();
            }
            else
            {
                Pet = pet;
                PetHealth = petHealth;
                VaccinationRecordList = vaccinationRecordList;
                MedicineList = medicineList;
                //MedicalRecord = medicalRecord;
            }
            return Page();
        }
    }
}
