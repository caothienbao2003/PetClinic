using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class ConfirmationFormModel : PageModel
    {
        private readonly IPrescriptionService prescriptionService;
        private readonly IMedicineService medicineService;
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IServiceService serviceService;
        private IUserService userService;

        public ConfirmationFormModel(IMedicineService _medicineService, IPrescriptionService _prescriptionService, IMedicalRecordService _medicalRecordService, IServiceService _serviceService ,IUserService _userService)
        {
            medicineService = _medicineService;
            prescriptionService = _prescriptionService;
            medicalRecordService = _medicalRecordService;
            serviceService = _serviceService;
            userService = _userService;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; }

        [BindProperty]
        public Prescription Prescription { get; set; }

        [BindProperty]
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; }

        [BindProperty]
        public int MedicalRecordId { get; set; }

        public IActionResult OnGet(int medicalRecordId)
        {
            MedicalRecord = medicalRecordService.GetMedicalRecordById(medicalRecordId);
            Prescription = prescriptionService.GetPrescriptionByMedicalRecordId(medicalRecordId);
            PrescriptionMedicines = prescriptionService.GetMedicineByPrescriptionId(Prescription.PrescriptionId);

            if (MedicalRecord == null || Prescription == null || PrescriptionMedicines == null)
            {
                return NotFound();
            }

            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");
            ViewData["DoctorId"] = new SelectList(userService.GetAllUsers(), "DoctorId", "DoctorName");
            ViewData["ServiceId"] = new SelectList(serviceService.GetAllServices(), "ServiceId", "ServiceName");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                medicalRecordService.UpdateMedicalRecord(MedicalRecord);
                prescriptionService.UpdatePrescription(Prescription);

                foreach (var pm in PrescriptionMedicines)
                {
                    prescriptionService.UpdatePrescriptionMedicine(pm);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalRecordExists(MedicalRecord.MedicalRecordId))
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

        private bool MedicalRecordExists(int id)
        {
            return medicalRecordService.GetMedicalRecordById(id) != null;
        }
    }
}

