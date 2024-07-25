using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicServices;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageMedicine
{
	public class AdminViewMedicineListModel : PageModel
	{
		private readonly IMedicineService medicineService;
		private readonly IMedicineTypeService medicineTypeService;
		public AdminViewMedicineListModel(IMedicineService _medicineService, IMedicineTypeService _medicineTypeService)
		{
			medicineService = _medicineService;
			medicineTypeService = _medicineTypeService;
		}


        [BindProperty(SupportsGet = true)]
        public string searchMedicineName { get; set; }

        [BindProperty(SupportsGet = true)]
		public int? searchMedicineType { get; set; }

        [BindProperty]
		public List<Medicine> Medicines { get; set; }
        public List<MedicineType> MedicineTypes { get; set; }



        [BindProperty]
		public List<Medicine> MedicineListWithoutInlcude { get; set; }

		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }

        


        [BindProperty]
		public string newMedicineName { get; set; }
		[BindProperty]
		public string newMedicineDescription { get; set; }
		[BindProperty]
		public int newMedicineTypeId { get; set; }
		[BindProperty]
		public int ActiveStatus { get; set; }

		public void OnGet()
		{
			InitializePage();
			LoadMedicineListWithoutInclude();

			//ViewData["MedicineTypeId"] = new SelectList(medicineTypeService.GetMedicineTypeList(), "MedicineTypeId", "MedicineTypeName");
		}

		public void OnPostCreateMedicine()
		{
			try
			{
				var newMedicine = new Medicine
				{
					MedicineName = newMedicineName,
					MedicineDescription = newMedicineDescription,
					MedicineTypeId = newMedicineTypeId,
					ActiveStatus = 1
				};

				medicineService.AddMedicine(newMedicine);
				InitializePage();
				LoadMedicineListWithoutInclude();
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, "Error occurred while creating medicine (2).");
				InitializePage();
				LoadMedicineListWithoutInclude();

			}
		}
			

		private void InitializePage()
		{
			Medicines = medicineService.SearchMedicines(searchMedicineName, searchMedicineType);
            MedicineTypes = medicineTypeService.GetMedicineTypeList();
			ViewData["MedicineTypeId"] = new SelectList(medicineTypeService.GetMedicineTypeList(), "MedicineTypeId", "MedicineTypeName");
        }

		private void LoadMedicineListWithoutInclude()
		{
			MedicineListWithoutInlcude = medicineService.GetMedicineListWithoutInclude();
		}
	}
}
