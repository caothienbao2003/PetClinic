using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
	public class CreateVaccinationModel : PageModel
	{
		private readonly IPetService petService;
		private readonly IMedicineService medicineService;
		private readonly IMedicineTypeService medicineTypeService;
		private readonly IVaccinationRecordService vaccinationRecordService;

		public CreateVaccinationModel(IPetService _petService, IMedicineService _medicineService, IMedicineTypeService _medicineTypeService, IVaccinationRecordService _vaccinationRecordService)
		{
			petService = _petService;
			medicineService = _medicineService;
			medicineTypeService = _medicineTypeService;
			vaccinationRecordService = _vaccinationRecordService;
		}

		[BindProperty]
		public PetHealth? PetHealthInfo { get; set; } = default!;

		[BindProperty]
		public VaccinationRecord VaccinationRecord { get; set; } = default!;

		[BindProperty]
		public List<VaccinationRecord>? VaccinationRecordsList { get; set; } = default!;

		[BindProperty]
		public int? MedicineTypeId { get; set; }

		public int MedicalRecordId { get; set; }

		public IActionResult OnGet(int petHealthId, int medicalRecordId)
		{
			var medicines = medicineService.GetMedicineList().Where(m => m.MedicineType.MedicineTypeName == "Vaccine").ToList();
			ViewData["MedicineId"] = new SelectList(medicines, "MedicineId", "MedicineName");

			MedicalRecordId = medicalRecordId;
			VaccinationRecordsList = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(petHealthId);
			return Page();
		}

		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public IActionResult OnPost(int petHealthId)
		{
			VaccinationRecord.PetHealthId = petHealthId;
			VaccinationRecord.Verification = true;
			vaccinationRecordService.AddVaccinationRecord(VaccinationRecord);

			// Refresh the list of vaccination records
			VaccinationRecordsList = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(petHealthId);

			return RedirectToPage(new { petHealthId = petHealthId, medicalRecordId = MedicalRecordId });
		}

		public IActionResult OnPostToggleVerification(int recordId, int petHealthId)
		{
			var record = vaccinationRecordService.GetVaccinationRecordById(recordId);
			if (record != null)
			{
				record.Verification = !record.Verification;
				vaccinationRecordService.UpdateVaccinationRecord(record);
			}
            VaccinationRecordsList = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(petHealthId);

			return RedirectToPage(new { petHealthId = petHealthId, medicalRecordId = MedicalRecordId });
		}
	}
}
