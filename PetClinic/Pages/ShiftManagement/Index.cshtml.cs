using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;

namespace PetClinic.Pages.ShiftManager
{
    public class IndexModel : PageModel
    {
        private IShiftService shiftService;

        public IndexModel(IShiftService shiftService)
        {
            this.shiftService = shiftService;
        }

        [BindProperty]
        public List<Shift> ShiftList { get;set; } = default!;

        public void OnGet()
        {
            ShiftList = shiftService.GetAllShifts();
        }
    }
}
