using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
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
		[BindProperty]
		public List<Medicine> Medicines { get; set; }

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

			Console.WriteLine(medicineTypeService.GetMedicineTypeList());

			ViewData["MedicineTypeId"] = new SelectList(medicineTypeService.GetMedicineTypeList(), "MedicineTypeId", "MedicineTypeName");
		}

		public IActionResult OnPostCreateMedicine()
		{
			if (!ModelState.IsValid)
			{
				InitializePage();
				ModelState.Clear();
				ModelState.AddModelError(string.Empty, "Error occurred while creating service.");
				return Page(); // Stay on the page with validation errors
			}

			try
			{
				Medicine Medicine = medicineService.GetMedicineById(newMedicineTypeId);
				if (Medicine == null)
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
					return Page();
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Medicine already exists.");
					ViewData["MedicineTypeId"] = new SelectList(medicineTypeService.GetMedicineTypeList(), "MedicineTypeId", "MedicineTypeName");
					return Page();
				}

			}
			catch (Exception ex)
			{
				InitializePage();
				ModelState.AddModelError(string.Empty, "Error occurred while creating service.");
				return Page();
			}
		}

		private void InitializePage()
		{
			Medicines = medicineService.GetMedicineList();
		}
	}
}
