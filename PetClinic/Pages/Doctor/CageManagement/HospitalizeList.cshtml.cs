using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor.CageManagement
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
            var userId = HttpContext.Session.GetString("UserId");

            CageId = cageId;

            var hospitalizes = hospitalizeService.GetListByCageId(CageId) ?? new List<Hospitalize>();

            Hospitalizes = hospitalizes.Where(h => h.DoctorId.ToString() == userId).ToList();

            Hospitalizes = Hospitalizes.OrderBy(h => h.OutTime == null ? 0 : 1).ThenByDescending(h => h.OutTime).ToList();

            foreach (var hospitalize in Hospitalizes)
            {
                hospitalize.HospitalizeLogs = hospitalizeService.GetLogListByHospitalizeId(hospitalize.HospitalizeId);

            }

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostCreateLog(int HospitalizeId, string Description)
        {
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
                    ActiveStatus = (int)ActiveStatus.Active
                };
                hospitalizeService.AddHospitalizeLog(endLog);

                var cage = cageService.GetCageById(hospitalize.CageId!.Value);
                if (cage != null)
                {
                    cage.CageStatus = (int)CageStatus.Available;
                    cageService.UpdateCage(cage);
                }
            }

            return RedirectToPage(new { cageId = CageId });
        }

        public IActionResult OnPostToggleLogStatus(int logId, int hospitalizeId)
        {
            var log = hospitalizeService.GetLogById(logId);
            if (log == null)
            {
                return NotFound();
            }

            log.ActiveStatus = log.ActiveStatus == (int)ActiveStatus.Active ? (int)ActiveStatus.UnActive : (int)ActiveStatus.Active;
            hospitalizeService.UpdateHospitalizeLog(log);

            return RedirectToPage(new { cageId = CageId });
        }
    }
}
