using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class ChooseDateShiftDoctorModel : PageModel
    {
        private readonly IShiftService _shiftService;
        private readonly IDoctorService _doctorService;

        public ChooseDateShiftDoctorModel(IShiftService shiftService, IDoctorService doctorService)
        {
            _shiftService = shiftService;
            _doctorService = doctorService;
        }

        [BindProperty]
        public DateTime SelectedDate { get; set; }

        [BindProperty]
        public int SelectedShiftId { get; set; }

        [BindProperty]
        public int SelectedDoctorId { get; set; }

        public List<Shift> ShiftList { get; set; }

        public List<User> DoctorList { get; set; }

        [BindProperty(SupportsGet = true)]
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

            LoadData();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Request.Form.ContainsKey("SelectedDate"))
            {
                SelectedDate = DateTime.Parse(Request.Form["SelectedDate"]);
                LoadData(); // Load shifts and doctors based on the selected date
                return Page();
            }

            // Handle form submission logic here
            TempData["SelectedDate"] = SelectedDate;
            TempData["SelectedPetId"] = SelectedPetId;
            TempData["SelectedShiftId"] = SelectedShiftId;
            TempData["SelectedDoctorId"] = SelectedDoctorId;

            return RedirectToPage("/BookingManagement/ChooseDateAndShift", new { SelectedPetId, SelectedDate, SelectedShiftId, SelectedDoctorId });
        }

        private void LoadData()
        {
            //ShiftList = _shiftService.GetShiftsByDate(SelectedDate);
            //DoctorList = _doctorService.GetDoctorsByDate(SelectedDate);
            ShiftList = _shiftService.GetAllDoctorShifts();
            DoctorList = _doctorService.GetAllDoctors();
        }
    }
}
