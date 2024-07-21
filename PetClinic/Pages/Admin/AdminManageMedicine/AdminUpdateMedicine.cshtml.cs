using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageMedicine
{
	public class AdminUpdateMedicineModel : PageModel
	{
		[BindProperty]
		public decimal revenue { get; set; }
		[BindProperty]
		public int totalCustomers { get; set; }
		[BindProperty]
		public int totalBookings { get; set; }
		[BindProperty]
		public int updateMedicineId { get; set; }
		[BindProperty]
		public string updateMedicineName { get; set; }
		[BindProperty]
		public string updateMedicineDescription { get; set; }
		[BindProperty]
		public int updateActiveStatus { get; set; }

		[BindProperty]
		public int updateMedicineTypeId { get; set; }

		public Medicine existingMedicine { get; set; }

		private readonly IMedicineService medicineService;
		private readonly IMedicineTypeService medicineTypeService;

		public AdminUpdateMedicineModel(IMedicineService _medicineService, IMedicineTypeService _medicineTypeService)
		{
			medicineService = _medicineService;
			medicineTypeService = _medicineTypeService;
		}

		public void OnGet(int medicineId)
		{
			Console.WriteLine("hahahahah");

			existingMedicine = medicineService.GetMedicineById(medicineId);

			ViewData["MedicineTypeId"] = new SelectList(medicineTypeService.GetMedicineTypeList(), "MedicineTypeId", "MedicineTypeName");

			if (existingMedicine != null)
			{
				updateMedicineId = existingMedicine.MedicineId;
				updateMedicineName = existingMedicine.MedicineName;
				updateMedicineDescription = existingMedicine.MedicineDescription;
				updateActiveStatus = (int)existingMedicine.ActiveStatus;
				updateMedicineTypeId = (int)existingMedicine.MedicineTypeId;
			}
		}

		public void OnPost()
		{
			if (!ModelState.IsValid)
			{
				return;
			}

			Medicine existingMedicine = medicineService.GetMedicineById(updateMedicineId);
			if (existingMedicine == null)
			{
				ModelState.AddModelError(string.Empty, "Medicine not found");
				return;
			}

			try
			{
				existingMedicine.MedicineName = updateMedicineName;
				existingMedicine.MedicineDescription = updateMedicineDescription;
				existingMedicine.ActiveStatus = updateActiveStatus;
				existingMedicine.MedicineTypeId = updateMedicineTypeId;

				medicineService.UpdateMedicine(existingMedicine);

				Response.Redirect("/Admin/AdminManageMedicine/AdminViewMedicineList");
			}
			catch
			{
				ModelState.AddModelError(string.Empty, "Error occurred while updating service.");
				return;
			}
		}

	}
}
