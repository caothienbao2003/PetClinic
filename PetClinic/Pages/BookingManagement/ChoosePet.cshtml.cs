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

        public ChoosePetModel(IPetService _petService)
        {
            petService = _petService;
        }

        [BindProperty]
        public int SelectedPetId { get; set; }
        [BindProperty]
        public List<Pet> PetList { get; set; }

        public void OnGet()
        {
            string userIdString = HttpContext.Session.GetString("UserId");

            if (userIdString != null)
            {
                int userId = int.Parse(userIdString);
                PetList = petService.GetPetListByUserId(userId);
                ViewData["PetList"] = new SelectList(PetList, "PetId", "PetName");
            }

        }

        public void OnPost()
        {
            if (PetList.IsNullOrEmpty())
            {
                ViewData["PetList"] = new SelectList(PetList, "PetId", "PetName");
                TempData["SelectedPetId"] = SelectedPetId;
            }

            Response.Redirect("ChooseDate");
        }
    }
}
