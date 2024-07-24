using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinic.Session;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class CreatePrescriptionModel : PageModel
    {
        private readonly IMedicineService medicineService;
        private readonly IMedicineTypeService medicineTypeService;
        private readonly IPrescriptionService prescriptionService;

        public CreatePrescriptionModel(IMedicineService _medicineService, IMedicineTypeService _medicineTypeService, IPrescriptionService _prescriptionService)
        {
            medicineService = _medicineService;
            medicineTypeService = _medicineTypeService;
            prescriptionService = _prescriptionService;
        }

        [BindProperty]
        public PrescriptionMedicine PrescriptionMedicine { get; set; } = new PrescriptionMedicine();

        [BindProperty]
        public int MedicalRecordId { get; set; }

        [BindProperty]
        public int? MedicineTypeId { get; set; }

        [BindProperty]
        public Prescription Prescription { get; set; }

        [BindProperty]
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

        public IActionResult OnGet(int medicalRecordId)
        {
            MedicalRecordId = medicalRecordId;
            SetViewBags();
            LoadPrescriptionMedicinesFromSession();
            return Page();
        }

        public IActionResult OnPost()
        {
            UpdatePrescriptionMedicinesInSession();
            LoadPrescriptionMedicinesFromSession();
            SetViewBags();
            return Page();
        }

        public IActionResult OnPostDelete(int medicineId)
        {
            RemoveMedicineFromSession(medicineId);
            LoadPrescriptionMedicinesFromSession();
            SetViewBags();
            return Page();
        }

        private void SetViewBags()
        {
            var medicineTypes = medicineTypeService.GetMedicineTypeList();
            ViewData["MedicineTypeId"] = new SelectList(medicineTypes ?? new List<MedicineType>(), "MedicineTypeId", "MedicineTypeName");

            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");
        }

        public IActionResult OnPostSave()
        {
            SavePrescription();
            ClearPrescriptionMedicinesFromSession();
            return RedirectToPage("/Doctor/MedicalRecordManagement/ConfirmationForm", new { medicalRecordId = MedicalRecordId });
        }

        public JsonResult OnGetFilterMedicines(int typeId)
        {
            var medicines = typeId == 0 ? medicineService.GetMedicineList() : medicineService.GetMedicineList().Where(m => m.MedicineTypeId == typeId).ToList();
            var result = medicines.Select(m => new { m.MedicineId, m.MedicineName }).ToList();
            return new JsonResult(result);
        }

        private void LoadPrescriptionMedicinesFromSession()
        {
            var sessionPrescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines");
            PrescriptionMedicines = sessionPrescriptionMedicines ?? new List<PrescriptionMedicine>();

            foreach (var pm in PrescriptionMedicines)
            {
                pm.Medicine = medicineService.GetMedicineById(pm.MedicineId);
            }
        }

        private void UpdatePrescriptionMedicinesInSession()
        {
            var sessionPrescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines") ?? new List<PrescriptionMedicine>();

            var existingMedicine = sessionPrescriptionMedicines.FirstOrDefault(pm => pm.MedicineId == PrescriptionMedicine.MedicineId);
            if (existingMedicine != null)
            {
                existingMedicine.MedicineQuantity = PrescriptionMedicine.MedicineQuantity;
                existingMedicine.Dosage = PrescriptionMedicine.Dosage;
            }
            else
            {
                sessionPrescriptionMedicines.Add(PrescriptionMedicine);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "PrescriptionMedicines", sessionPrescriptionMedicines);
        }

        private void RemoveMedicineFromSession(int medicineId)
        {
            var sessionPrescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines") ?? new List<PrescriptionMedicine>();
            var medicineToRemove = sessionPrescriptionMedicines.FirstOrDefault(pm => pm.MedicineId == medicineId);
            if (medicineToRemove != null)
            {
                sessionPrescriptionMedicines.Remove(medicineToRemove);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "PrescriptionMedicines", sessionPrescriptionMedicines);
            }
        }

        private void SavePrescription()
        {
            Prescription.MedicalRecordId = MedicalRecordId;
            prescriptionService.AddPrescription(Prescription);

            var prescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines");
            if (prescriptionMedicines != null && prescriptionMedicines.Any())
            {
                foreach (var pm in prescriptionMedicines)
                {
                    pm.PrescriptionId = Prescription.PrescriptionId;
                    prescriptionService.AddPrescriptionMedicine(pm);
                }
            }
        }

        private void ClearPrescriptionMedicinesFromSession()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "PrescriptionMedicines", new List<PrescriptionMedicine>());
        }
    }
}
