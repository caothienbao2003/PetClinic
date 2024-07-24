using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class MedicalRecordDetailsModel : PageModel
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IPetHealthService petHealthService;
        private readonly IBookingService bookingService;
        private readonly IMedicineService medicineService;
        private readonly IPrescriptionService prescriptionService;

        public MedicalRecordDetailsModel(IMedicalRecordService _medicalRecordService, IPetHealthService _petHealthService, IBookingService _bookingService, IMedicineService _medicineService, IPrescriptionService _prescriptionService)
        {
            medicalRecordService = _medicalRecordService;
            petHealthService = _petHealthService;
            bookingService = _bookingService;
            medicineService = _medicineService;
            prescriptionService = _prescriptionService;
        }

        public MedicalRecord MedicalRecord { get; set; } = default!; 

        public PetHealth PetHealth { get; set; } = default!;

        [BindProperty]
        public Prescription Prescription { get; set; }

        [BindProperty]
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } = default!; 

        public IActionResult OnGet(int bookId)
        {
            var medicalrecord = medicalRecordService.GetMedicalRecordById(bookId);
            MedicalRecord = medicalrecord;

            //Pet Health Info
            var booking = bookingService.GetBookingById(MedicalRecord.BookingId!.Value);

            PetHealth = petHealthService.GetPetHealthByPetId(booking!.PetId!.Value);

            //Prescription Info
            var prescription = prescriptionService.GetPrescriptionByMedicalRecordId(MedicalRecord.MedicalRecordId);
            if (prescription != null)
            {
                Prescription = prescription;
                PrescriptionMedicines = prescriptionService.GetMedicineByPrescriptionId(Prescription.PrescriptionId);
            }

            return Page();
        }
    }
}
