using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace PetClinic.Pages.BookingManagement
{
    public class ChooseDateModel : PageModel
    {
        [BindProperty]
        public DateTime SelectedDate { get; set; }

        [BindProperty]
        public int SelectedPetId { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("SelectedPetId"))
            {
                SelectedPetId = (int)TempData["SelectedPetId"];
                TempData.Keep("SelectedPetId");
            }

            if (SelectedDate == default(DateTime))
            {
                SelectedDate = DateTime.Today.AddDays(1); // Default to tomorrow if no date is selected
            }
        }

        public void OnPost()
        {
            if (SelectedDate < DateTime.Today.AddDays(1))
            {
                ModelState.AddModelError(string.Empty, "Please select a date starting from tomorrow.");
            }

            // Save the selected date and proceed to the next page
            TempData["SelectedDate"] = SelectedDate;
            TempData["SelectedPetId"] = SelectedPetId;

            Response.Redirect("/BookingManagement/ChooseShiftAndDoctor");
        }
    }
}
