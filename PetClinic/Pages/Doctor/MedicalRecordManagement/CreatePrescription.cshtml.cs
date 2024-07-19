using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinic.Session;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class CreatePrescriptionModel : PageModel
    {
        private readonly IPrescriptionService prescriptionService;
        private readonly IMedicineService medicineService;

        public CreatePrescriptionModel(IMedicineService _medicineService, IPrescriptionService _prescriptionService)
        {
            medicineService = _medicineService;
            prescriptionService = _prescriptionService;
        }

        [BindProperty]
        public PrescriptionMedicine PrescriptionMedicine { get; set; } = new PrescriptionMedicine();

        [BindProperty]
        public int MedicalRecordId { get; set; }

        [BindProperty]
        public Prescription Prescription { get; set; }

        [BindProperty]
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; }

        public IActionResult OnGet(int medicalRecordId)
        {
            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");
            MedicalRecordId = medicalRecordId;
            
            var prescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines");
            PrescriptionMedicines = prescriptionMedicines ?? new List<PrescriptionMedicine>();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (PrescriptionMedicines == null)
            {
                PrescriptionMedicines = new List<PrescriptionMedicine>();
            }

            var sessionPrescriptionMedicines = SessionHelper.GetObjectFromJson<List<PrescriptionMedicine>>(HttpContext.Session, "PrescriptionMedicines");

            if (sessionPrescriptionMedicines != null)
            {
                PrescriptionMedicines = sessionPrescriptionMedicines;
            }

            if (PrescriptionMedicine != null)
            {
                PrescriptionMedicines.Add(PrescriptionMedicine);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "PrescriptionMedicines", PrescriptionMedicines);

            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");
            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostSave()
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

            SessionHelper.SetObjectAsJson(HttpContext.Session, "PrescriptionMedicines", new List<PrescriptionMedicine>());
            return RedirectToPage("/Doctor/MedicalRecordManagement/ConfirmationForm", new { medicalRecordId = MedicalRecordId });
        }
    }
}
