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
        private readonly IVaccinationDetailService vaccinationDetailService;

        public IndexModel(IVaccinationDetailService _vaccinationDetailService)
        {
            vaccinationDetailService = _vaccinationDetailService;
        }

        public List<VaccinationDetail> vaccinationDetailsList { get;set; } = default!;

        public void OnGet()
        {
            vaccinationDetailsList = vaccinationDetailService.GetVaccinationDetailsList();
        }
    }
}
