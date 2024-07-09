using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.StaffPages.CageManagement
{
    public class HospitalizeListModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly ICageService cageService;

        public HospitalizeListModel(IHospitalizeService _hospitalizeService, ICageService _cageService)
        {
            hospitalizeService = _hospitalizeService;
            cageService = _cageService;
        }

        [BindProperty(SupportsGet = true)]
        public int CageId { get; set; }

        public List<Hospitalize> Hospitalize { get; set; } = default!;

        public IActionResult OnGet(int cageId)
        {
            CageId = cageId;
            Hospitalize = hospitalizeService.GetListByCageId(CageId);
            return Page();
        }

        public IActionResult OnPost(int HospitalizeId)
        {
            var hospitalizeFromDb = hospitalizeService.GetHospitalizeById(HospitalizeId);
            if (hospitalizeFromDb != null)
            {
                hospitalizeFromDb.OutTime = DateTime.Now;
                hospitalizeService.UpdateHospitalize(hospitalizeFromDb);

                var cage = cageService.GetCageById(hospitalizeFromDb.CageId!.Value);
                if (cage != null)
                {
                    cage.CageEnumStatus = CageStatus.Available;
                    cageService.UpdateCage(cage);
                }
            }

            return RedirectToPage("/StaffPages/CageManagement/Index");
        }
    }
}
