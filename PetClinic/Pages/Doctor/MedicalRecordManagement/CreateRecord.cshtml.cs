using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public CreateRecordModel(IMedicalRecordService _medicalRecordService, IBookingService _bookingService, IUserService _userService, 
            IPetService _petService, IVaccinationRecordService _vaccinationRecordService, IMedicineService _medicineService)
        {
            medicalRecordService = _medicalRecordService;
            bookingService = _bookingService;
            userService = _userService;
            petService = _petService;
            vaccinationRecordService = _vaccinationRecordService;
            medicineService = _medicineService;
        }

        [BindProperty(SupportsGet = true)]
        public int BookId { get; set; }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = new MedicalRecord();

        [BindProperty]
        public Booking? Book { get; set; } = default!;

        [BindProperty]
        public PetHealth? PetHealthInfo { get; set; } = default!;

        [BindProperty]
        public List<VaccinationRecord> records { get; set; } = default!;

        public bool IsMedicalRecordCreated { get; set; } = false;


        [BindProperty(SupportsGet = true)]
        public int MecId { get; set; }

        public IActionResult OnGet(int bookid, bool? isMedicalRecordCreated, int mecId = 0)
        {
            BookId = bookid;

            var booking = bookingService.GetBookingById(bookid);

            Book = booking;

            if(mecId != 0)
            {
                MecId = mecId;
                MedicalRecord = medicalRecordService.GetMedicalRecordById(mecId);
            }   

            if(booking == null)
            {
                return NotFound();
            }

            PetHealthInfo = petService.GetPetHealthByPetId(booking!.PetId);

            records = vaccinationRecordService.GetVaccinationRecordsByPetHealthId(PetHealthInfo.PetHealthId);

            var undesiredServiceNames = new List<string> { "Booking Fee", "Emergency Care" };

            var filteredService = medicalRecordService.GetServices()
                          .Where(s => !undesiredServiceNames.Contains(s.ServiceName!))
                          .ToList();


            ViewData["DoctorId"] = new SelectList(userService.GetAllUsers(), "UserId", "FirstName", null);
            ViewData["ServiceId"] = new SelectList(filteredService, "ServiceId", "ServiceName", null);
            ViewData["MedicineId"] = new SelectList(medicineService.GetMedicineList(), "MedicineId", "MedicineName");

            if (isMedicalRecordCreated.HasValue)
            {
                IsMedicalRecordCreated = isMedicalRecordCreated.Value;
            }

            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            MedicalRecord.BookingId = BookId;

            medicalRecordService.AddMedicalRecord(MedicalRecord);

            var booking = bookingService.GetBookingById(BookId);
            //if (booking != null)
            //{
            //    booking.BookingStatus = 2; // Or the desired status
            //    bookingService.UpdateBooking(booking);
            //}

            return RedirectToPage(null, new { bookid = BookId, IsMedicalRecordCreated = true, mecId = MedicalRecord.MedicalRecordId });
        }
    }
}
