using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManagePet
{
    public class AdminViewPetListModel : PageModel
    {
        [BindProperty]
        public decimal revenue { get; set; }
        [BindProperty]
        public int totalCustomers { get; set; }
        [BindProperty]
        public int totalBookings { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchPetName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchCustomer { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchPetType { get; set; }



        private readonly IPetService petService;
        public AdminViewPetListModel(IPetService _petService)
        {
            petService = _petService;
        }
        public List<Pet> petList { get; set; } = default!;
        public List<string> petTypes { get; set; } = new List<string>();


        public void OnGet()
        {
            petTypes = petService.GetAllPetTypes();
            petList = petService.SearchPets(searchPetName, searchCustomer, searchPetType);
        }
    }
}
