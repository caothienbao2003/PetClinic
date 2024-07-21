using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetClinicBussinessObject;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageMedicine
{
    public class AdminViewMedicineListModel : PageModel
    {
        private readonly IMedicineService medicineService;

		public AdminViewMedicineListModel(IMedicineService _medicineService)
        {
			medicineService = _medicineService;
		}
		[BindProperty]
		public List<Medicine> Medicines { get; set; }

		public void OnGet()
        {
			InitializePage();
		}




		private void InitializePage()
		{
			Medicines = medicineService.GetMedicineList();
		}
	}
}
