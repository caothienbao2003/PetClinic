using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices.Interface;

namespace PetClinic.Pages.VaccinationManagement
{
    public class IndexModel : PageModel
    {
        private readonly IVaccinationRecordService vaccinationRecordService;

        public IndexModel(IVaccinationRecordService _vaccinationRecordService)
        {
            vaccinationRecordService = _vaccinationRecordService;
        }

        public List<VaccinationRecord> vaccinationRecordList { get;set; } = default!;

        public void OnGet()
        {
            vaccinationRecordList = vaccinationRecordService.GetVaccinationRecordsList();
        }
    }
}
