using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class ChoosePetModel : PageModel
    {
        private IPetService petService;
        private List<Pet> petList;

        public ChoosePetModel(IPetService _petService)
        {
            petService = _petService;
        }

        [BindProperty]
        public int SelectedPetId { get; set; }

        public void OnGet()
        {
            string userIdString = HttpContext.Session.GetString("UserId");

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);
                petList = petService.GetPetListByUserId(userId);
                ViewData["PetList"] = new SelectList(petList, "PetId", "PetName");
            }

        }

        public void OnPost()
        {
            if (petList.IsNullOrEmpty())
            {
                ViewData["PetList"] = new SelectList(petList, "PetId", "PetName");
                TempData["SelectedPetId"] = SelectedPetId;
            }

            Response.Redirect("ChooseDate");
        }
    }
}
