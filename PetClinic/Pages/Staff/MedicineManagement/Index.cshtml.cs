using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.MedicineManagement
{
    public class IndexModel : PageModel
    {
        private readonly IMedicineService medicineService;

        public IndexModel(IMedicineService _medicineService)
        {
            medicineService = _medicineService;
        }

        public List<Medicine> medicineList { get; set; } = default!;

        public void OnGet()
        {
            medicineList = medicineService.GetMedicineList();
        }
    }
}
