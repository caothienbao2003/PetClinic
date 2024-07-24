using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Doctor
{
    public class HospitalizeListModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly ICageService cageService;
        private readonly IUserService userService;

        public HospitalizeListModel(IHospitalizeService _hospitalizeService, ICageService _cageService, IUserService _userService)
        {
            hospitalizeService = _hospitalizeService;
            cageService = _cageService;
            userService = _userService;
        }

        [BindProperty(SupportsGet = true)]
        public int CageId { get; set; }

        [BindProperty]
        public User user { get; set; } = default!;

        public List<Hospitalize> Hospitalizes { get; set; } = default!;

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }

            var hospitalizes = hospitalizeService.GetAllHospitalize() ?? new List<Hospitalize>();

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
