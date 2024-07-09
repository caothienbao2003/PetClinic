using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.DoctorPages.MedicalRecords
{
    public class IndexModel : PageModel
    {
        private readonly IMedicalRecordService medicalRecordService;

        public IndexModel(IMedicalRecordService _medicalRecordService)
        {
            medicalRecordService = _medicalRecordService;
        }

        [BindProperty(SupportsGet = true)]
        public int BookingId { get; set; }

        public MedicalRecord MedicalRecord { get;set; } = default!;
  
        public IActionResult OnGet(int bookId)
        {
            BookingId = bookId;

            MedicalRecord = medicalRecordService.GetMedicalRecordByBookingId(BookingId);

            //MedicalRecord = medicalRecordService.GetMedicalRecordsList();
            return Page();
        }
    }
}
