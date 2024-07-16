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
    public class CreateModel : PageModel
    {
        private readonly PetClinicBussinessObject.PetClinicContext _context;
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IBookingService bookingService;
        private readonly IUserService userService;
        private readonly IPetService petService;
        private readonly IVaccinationRecordService vaccinationRecordService;
        private readonly IPrescriptionService prescriptionService;

        public CreateModel(PetClinicBussinessObject.PetClinicContext context, IMedicalRecordService _medicalRecordService, IBookingService _bookingService, IUserService _userService, IPetService _petService, IVaccinationRecordService _vaccinationRecordService)
        {
            _context = context;
            medicalRecordService = _medicalRecordService;
            bookingService = _bookingService;
            userService = _userService;
            petService = _petService;
            vaccinationRecordService = _vaccinationRecordService;
        }

        [BindProperty(SupportsGet = true)]
        public int BookId { get; set; }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        [BindProperty]
        public Booking? Book { get; set; } = default!;

        [BindProperty]
        public PetHealth? PetHealthInfo { get; set; } = default!;

        [BindProperty]
        public VaccinationRecord records { get; set; } = default!;

        public IActionResult OnGet(int bookid)
        {
            BookId = bookid;

            var booking = bookingService.GetBookingById(bookid);
            Book = booking;

            PetHealthInfo = petService.GetPetHealthByPetId(booking!.PetId);

            //if (PetHealthInfo?.VaccinationRecordId != null)
            //{
            //    records = vaccinationRecordService.GetVaccinationRecordByVaccinationRecordId(PetHealthInfo.VaccinationRecordId.Value);
            //}

            //foreach (var record in records)
            //{
            //    var detailedRecord = vaccinationRecordService.GetVaccinationRecordByVaccinationRecordsId(record.VaccinationRecordsId);
            //    record.VaccinationDetails = detailedRecord?.VaccinationDetails;
            //    if (record.VaccinationDetails != null)
            //    {
            //        record.VaccinationDetails.Medicine = detailedRecord!.VaccinationDetails!.Medicine;
            //    }
            //}

            records = petService.GetVaccinationRecordByPetHealthId(PetHealthInfo.PetHealthId);
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["DoctorId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceId");
            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            medicalRecordService.AddMedicalRecord(MedicalRecord);

            return RedirectToPage("./Index");
        }
    }
}
