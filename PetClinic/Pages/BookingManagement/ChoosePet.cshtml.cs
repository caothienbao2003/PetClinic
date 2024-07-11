using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;

namespace PetClinic.Pages.BookingManagement
{
    public class ChoosePetModel : PageModel
    {
        private readonly PetClinicContext context;

        public ChoosePetModel(PetClinicContext _context)
        {
            context = _context;
        }

        [BindProperty]
        public int SelectedPetId { get; set; }

        public void OnGet()
        {
            ViewData["PetList"] = new SelectList(context.Pets, "PetId", "PetName");
        }

        public void OnPost()
        {
            ViewData["PetList"] = new SelectList(context.Pets, "PetId", "PetName");

            TempData["SelectedPetId"] = SelectedPetId;

            Response.Redirect("ChooseDate");
        }
    }
}
