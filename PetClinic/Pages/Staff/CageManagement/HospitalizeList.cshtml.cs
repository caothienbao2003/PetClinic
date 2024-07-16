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

        public List<Hospitalize> Hospitalizes { get; set; } = default!;

        public IActionResult OnGet(int cageId)
        {
            CageId = cageId;

            Hospitalizes = hospitalizeService.GetListByCageId(CageId) ?? new List<Hospitalize>();

            Hospitalizes = Hospitalizes.OrderBy(h => h.OutTime == null ? 0 : 1).ThenByDescending(h => h.OutTime).ToList();

            foreach (var hospitalize in Hospitalizes)
            {
                hospitalize.HospitalizeLogs = hospitalizeService.GetLogListByHospitalizeId(hospitalize.HospitalizeId);

            }

            return Page();
        }

        public IActionResult OnPost()
        {
            //var hospitalize = hospitalizeService.GetHospitalizeById(HospitalizeId);
            //if (hospitalize != null)
            //{
            //    hospitalize.OutTime = DateTime.Now;
            //    hospitalizeService.UpdateHospitalize(hospitalize);

            //    var cage = cageService.GetCageById(hospitalize.CageId!.Value);
            //    if (cage != null)
            //    {
            //        cage.CageEnumStatus = CageStatus.Available;
            //        cageService.UpdateCage(cage);
            //    }
            //}

            return RedirectToPage("/StaffPages/CageManagement/Index");
        }

        public IActionResult OnPostCreateLog(int HospitalizeId, string Description)
        {
            //var hospitalize = hospitalizeService.GetHospitalizeById(HospitalizeId);
            //if (hospitalize == null || hospitalize.OutTime != null)
            //{
            //    return RedirectToPage("/Error");
            //}

            var newLog = new HospitalizeLog
            {
                HospitalizeId = HospitalizeId,
                DateTime = DateTime.Now,
                Description = Description,
                ActiveStatus = 1 
            };
            hospitalizeService.AddHospitalizeLog(newLog);

            return RedirectToPage(new { cageId = CageId });
        }

        public IActionResult OnPostEndHospitalize(int HospitalizeId)
        {
            var hospitalize = hospitalizeService.GetHospitalizeById(HospitalizeId);
            if (hospitalize != null && hospitalize.OutTime == null)
            {
                var endTime = DateTime.Now;
                hospitalize.OutTime = endTime;
                hospitalizeService.UpdateHospitalize(hospitalize);

                var endLog = new HospitalizeLog
                {
                    HospitalizeId = HospitalizeId,
                    DateTime = endTime,
                    Description = "End Hospitalization",
                    ActiveStatus = 1
                };
                hospitalizeService.AddHospitalizeLog(endLog);

                var cage = cageService.GetCageById(hospitalize.CageId!.Value);
                if (cage != null)
                {
                    cage.CageEnumStatus = CageStatus.Available;
                    cageService.UpdateCage(cage);
                }
            }

            return RedirectToPage(new { cageId = CageId });
        }


    }
}
