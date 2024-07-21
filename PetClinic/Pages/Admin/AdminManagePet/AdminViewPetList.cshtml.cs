using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManagePet
{
    public class AdminViewPetListModel : PageModel
    {
        private readonly IPetService petService;
        public AdminViewPetListModel(IPetService _petService)
        {
            petService = _petService;
        }
        public List<Pet> petList { get; set; } = default!;


        public void OnGet()
        {
            petList = petService.GetAll();
        }
    }
}
