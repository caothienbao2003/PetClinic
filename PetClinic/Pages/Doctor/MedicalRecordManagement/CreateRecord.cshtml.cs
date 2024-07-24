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
        private readonly IPetService petService;
        private readonly IPetHealthService petHealthService;
        private readonly IServiceService serviceService;

        public CreateRecordModel(IMedicalRecordService _medicalRecordService, IBookingService _bookingService,
            IPetService _petService, IPetHealthService _petHealthService,IServiceService _serviceService)
        {
            medicalRecordService = _medicalRecordService;
            bookingService = _bookingService;
            petService = _petService;
            petHealthService = _petHealthService;
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

        [BindProperty(SupportsGet = true)]
        public int petHealthId { get; set; }

        public bool? IsMedicalRecordCreated { get; set; } = false;

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
            if (petHealthId != 0)
            {
                PetHealthInfo = petHealthService.GetPetHealthById(petHealthId);
            }

            var undesiredServiceNames = new List<string> { "Booking Fee", "Emergency Care" };
            var filteredService = serviceService.GetAllServices()
                          .Where(s => !undesiredServiceNames.Contains(s.ServiceName!))
                          .ToList();

            ViewData["ServiceId"] = new SelectList(filteredService, "ServiceId", "ServiceName");

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

            return RedirectToPage(null, new { bookid = BookId, IsMedicalRecordCreated = true, mecId = MedicalRecord.MedicalRecordId, petHealthId = PetHealthInfo.PetHealthId });
        }

        public IActionResult OnPostUpdatePetHealth()
        {
            var existingPetHealth = petHealthService.GetPetHealthById(PetHealthInfo.PetHealthId);

            if (existingPetHealth == null)
            {
                existingPetHealth = new PetHealth
                {
                    PetId = PetHealthInfo.PetId
                };
            }

            existingPetHealth.Conditions = PetHealthInfo.Conditions ?? existingPetHealth.Conditions;
            existingPetHealth.Weight = PetHealthInfo.Weight ?? existingPetHealth.Weight;
            existingPetHealth.WeightMeasurementDate = PetHealthInfo.WeightMeasurementDate ?? existingPetHealth.WeightMeasurementDate;
            existingPetHealth.OverallHealth = PetHealthInfo.OverallHealth ?? existingPetHealth.OverallHealth;


            petHealthService.UpdatePetHealth(existingPetHealth);

            if (MedicalRecord.MedicalRecordId > 0)
            {
                MedicalRecord = medicalRecordService.GetMedicalRecordById(MedicalRecord.MedicalRecordId);
                IsMedicalRecordCreated = true;
            }

            return RedirectToPage(new { bookid = BookId, IsMedicalRecordCreated, mecId = MedicalRecord.MedicalRecordId, petHealthId = PetHealthInfo.PetHealthId });
        }
    }
}
