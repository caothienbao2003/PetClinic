using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.BookingManagement
{
    public class ChooseShiftAndDoctorModel : PageModel
    {
        private IShiftService shiftService;
        private IDoctorService doctorService;

        [BindProperty]
        public int SelectedShiftId { get; set; }
        [BindProperty]
        public int SelectedDoctorId {  get; set; }
        [BindProperty]
        public int SelectedDate { get; set; }
        [BindProperty]
        public int SelectedPetId { get; set; }

        [BindProperty]
        public List<Shift> ShiftList { get; set; }
        [BindProperty]
        public List<User> DoctorList { get; set; }

        public ChooseShiftAndDoctorModel(IShiftService _shiftService, IDoctorService _doctorService)
        {
            shiftService = _shiftService;
            doctorService = _doctorService;
        }

        public void OnGet()
        {
            ShiftList = shiftService.GetAllDoctorShifts();
            DoctorList = doctorService.GetAllDoctors();
        }
    }
}
