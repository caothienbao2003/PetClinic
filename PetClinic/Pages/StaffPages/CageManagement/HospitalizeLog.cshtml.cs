using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class HospitalizeLogModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly ICageService cageService;

        public HospitalizeLogModel(IHospitalizeService _hospitalizeService, ICageService _cageService)
        {
            hospitalizeService = _hospitalizeService;
            cageService = _cageService;
        }

        [BindProperty(SupportsGet = true)]
        public int HospitalizeId { get; set; }

        public List<HospitalizeLog> HospitalizeLog { get; set; } = default!;

        public IActionResult OnGet(int hospitalizeId)
        {
            HospitalizeId = hospitalizeId;
            HospitalizeLog = hospitalizeService.GetLogListByHospitalizeId(hospitalizeId);
            return Page();
        }
    }
}
