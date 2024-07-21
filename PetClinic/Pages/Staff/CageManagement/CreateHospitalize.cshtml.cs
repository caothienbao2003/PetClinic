using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Staff.CageManagement
{
    public class CreateHospitalizeModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly IUserService userSerivce;
        private readonly ICageService cageService;
        private readonly IPetService petService;

        public CreateHospitalizeModel(IHospitalizeService _hospitalizeService, IUserService _userSerivce, ICageService _cageService, IPetService _petService)
        {
            hospitalizeService = _hospitalizeService;
            userSerivce = _userSerivce;
            cageService = _cageService;
            petService = _petService;
        }

        [BindProperty(SupportsGet = true)]
        public int? CageId { get; set; }

        public IActionResult OnGet(int? cageId)
        {

            ViewData["DoctorId"] = new SelectList(userSerivce.GetUserListWithRole(UserRole.Doctor), "UserId", "FirstName");
            ViewData["PetId"] = new SelectList(petService.GetAll(), "PetId", "PetName");

            if (cageId.HasValue)
            {
                CageId = cageId;
                Hospitalize = new Hospitalize { CageId = cageId.Value };
            }

            return Page();
        }

        [BindProperty]
        public Hospitalize Hospitalize { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Hospitalize.InTime = DateTime.Now;

            if (CageId.HasValue)
            {
                Hospitalize.CageId = CageId.Value;
            }

            Hospitalize.ActiveStatus = (int)HospitalizeStatus.Show;

            hospitalizeService.AddHospitalize(Hospitalize);

            var hospitalizeFromDb = hospitalizeService.GetHospitalizeById(Hospitalize.HospitalizeId);
            if (hospitalizeFromDb == null || !hospitalizeFromDb.CageId.HasValue)
            {
                Console.WriteLine($"Unable to find hospitalize record with ID: {Hospitalize.HospitalizeId}");
                ModelState.AddModelError(string.Empty, "Unable to find hospitalize record or cage.");
                return Page();
            }

            var cage = cageService.GetCageById(hospitalizeFromDb.CageId.Value);

            if (cage != null)
            {
                cage.CageStatus = (int)CageStatus.Occupied;
                cage.ActiveStatus = (int)ActiveStatus.Active;
                cageService.UpdateCage(cage);
            }

            return RedirectToPage("./Index");
        }
    }
}
