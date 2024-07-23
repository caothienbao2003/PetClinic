using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.MedicalRecordManagement
{
    public class CreateRecordModel : PageModel
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IBookingService bookingService;
        private readonly IUserService userService;
        private readonly IPetService petService;
        private readonly IVaccinationRecordService vaccinationRecordService;
        private readonly IMedicineService medicineService;
        private readonly IServiceService serviceService;

        public CreateRecordModel(IMedicalRecordService _medicalRecordService, IBookingService _bookingService, IUserService _userService,
            IPetService _petService, IVaccinationRecordService _vaccinationRecordService, IMedicineService _medicineService, IServiceService _serviceService)
        {
            medicalRecordService = _medicalRecordService;
            bookingService = _bookingService;
            userService = _userService;
            petService = _petService;
            vaccinationRecordService = _vaccinationRecordService;
            medicineService = _medicineService;
            serviceService = _serviceService;
        }

        [BindProperty(SupportsGet = true)]
        public int BookId { get; set; }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = new MedicalRecord();

        [BindProperty]
        public Booking? Book { get; set; } = default!;

        [BindProperty]
        public PetHealth? PetHealthInfo { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int MecId { get; set; }

        [BindProperty]
        public VaccinationRecord NewVaccinationRecord { get; set; } = new VaccinationRecord();

        [BindProperty]
        public VaccinationRecord EditVaccinationRecord { get; set; }

        [BindProperty]
        public List<Medicine> MedicineList { get; set; } = new List<Medicine>();

        [BindProperty]
        public List<VaccinationRecord>? records { get; set; } = default!;

        public bool IsMedicalRecordCreated { get; set; } = false;

        public IActionResult OnGet(int bookid, bool? isMedicalRecordCreated, int mecId = 0)
        {
            BookId = bookid;
            var booking = bookingService.GetBookingById(bookid);

            if (booking == null)
            {
                return NotFound();
            }

            Book = booking;

            if (mecId != 0)
            {
                MecId = mecId;
                MedicalRecord = medicalRecordService.GetMedicalRecordById(mecId);
            }

            PetHealthInfo = petService.GetPetHealthByPetId(booking.PetId);

            records = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(PetHealthInfo.PetHealthId);

            var undesiredServiceNames = new List<string> { "Booking Fee", "Emergency Care" };
            var filteredService = serviceService.GetAllServices()
                          .Where(s => !undesiredServiceNames.Contains(s.ServiceName!))
                          .ToList();

            //ViewData["DoctorId"] = booking.Doctor.FirstName;
            ViewData["ServiceId"] = new SelectList(filteredService, "ServiceId", "ServiceName");
            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");

            MedicineList = medicineService.GetMedicineList();

            if (isMedicalRecordCreated.HasValue)
            {
                IsMedicalRecordCreated = isMedicalRecordCreated.Value;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            MedicalRecord.BookingId = BookId;
            medicalRecordService.AddMedicalRecord(MedicalRecord);

            var booking = bookingService.GetBookingById(BookId);
            if (booking != null)
            {
                booking.BookingStatus = (int)BookingStatus.Completed;
                bookingService.UpdateBooking(booking);
            }

            return RedirectToPage(null, new { bookid = BookId, IsMedicalRecordCreated = true, mecId = MedicalRecord.MedicalRecordId });
        }

        //public IActionResult OnPostAddVaccination()
        //{
        //    if (NewVaccinationRecord != null)
        //    {
        //        NewVaccinationRecord.Verification = NewVaccinationRecord.Verification;

        //        vaccinationRecordService.AddVaccinationRecord(NewVaccinationRecord);
        //    }

        //    var updatedRecords = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(NewVaccinationRecord!.PetHealthId!.Value);
        //    return new JsonResult(updatedRecords);
        //}

        //public IActionResult OnGetVaccinationRecord(int vaccinationRecordId)
        //{
        //    var record = vaccinationRecordService.GetVaccinationRecordById(vaccinationRecordId);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }
        //    return new JsonResult(record);
        //}

        //public IActionResult OnPostEditVaccination()
        //{
        //    var record = vaccinationRecordService.GetVaccinationRecordById(EditVaccinationRecord.VaccinationRecordId);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }

        //    record.VaccinationDate = EditVaccinationRecord.VaccinationDate;
        //    record.NextDueDate = EditVaccinationRecord.NextDueDate;
        //    record.VaccinatedAt = EditVaccinationRecord.VaccinatedAt;
        //    record.MedicineId = EditVaccinationRecord.MedicineId;
        //    record.Verification = EditVaccinationRecord.Verification;

        //    vaccinationRecordService.UpdateVaccinationRecord(record);

        //    var updatedRecords = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(EditVaccinationRecord.PetHealthId.Value);
        //    return new JsonResult(updatedRecords);
        //}

    }
}
