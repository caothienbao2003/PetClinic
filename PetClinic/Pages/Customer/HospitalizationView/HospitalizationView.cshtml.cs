using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Customer.HospitalizationView
{
    public class HospitalizationViewModel : PageModel
    {
        private readonly IHospitalizeService hospitalizeService;
        private readonly IPetService petService;
        private readonly IUserService userService;

        public HospitalizationViewModel(IHospitalizeService _hospitalizeService, IPetService _petService, IUserService _userService)
        {
            hospitalizeService = _hospitalizeService;
            petService = _petService;
            userService = _userService;
        }

        [BindProperty(SupportsGet = true)]
        public int CageId { get; set; }

        [BindProperty]
        public User user { get; set; } = default!;

        [BindProperty]
        public Pet pet { get; set; } = default!;

        [BindProperty]
        public List<Hospitalize> Hospitalizes { get; set; } = default!;

        public IActionResult OnGet()
        {
            string userId = HttpContext.Session.GetString("UserId");
            if (userId == null)
            {
                user = new User();
            }
            else
            {
                user = userService.GetUserById(int.Parse(userId));
            }

            var petList = petService.GetPetListByUserId(int.Parse(userId));
            foreach(var pet in petList)
            {
                Hospitalizes = hospitalizeService.GetHospitalizeByPetId(pet.PetId);
                foreach (var hospitalize in Hospitalizes)
                {
                    hospitalize.HospitalizeLogs = hospitalizeService.GetLogListByHospitalizeId(hospitalize.HospitalizeId);
                }
            }

            return Page();
        }
    }
}
