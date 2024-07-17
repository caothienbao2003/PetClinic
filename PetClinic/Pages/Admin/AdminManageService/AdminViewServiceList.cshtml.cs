using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PetClinicBussinessObject;
using PetClinicServices.Interface;
using PetClinicServices;
using PetClinicDAO;
using System.Net;

namespace PetClinic.Pages.Admin.AdminManageService
{
    public class AdminViewServiceListModel : PageModel
    {
        [BindProperty]
        public decimal revenue { get; set; }
        [BindProperty]
        public int totalCustomers { get; set; }
        [BindProperty]
        public int totalBookings { get; set; }

        [BindProperty]
        public int updateServiceId { get; set; }

        [BindProperty]
        public string updateServiceName { get; set; }
        [BindProperty]
        public int updateServicePrice { get; set; }
        [BindProperty]
        public string updateServiceDescription { get; set; }
        [BindProperty]
        public int updateActiveStatus { get; set; }


        [BindProperty]
        public string newServiceName { get; set; }
        [BindProperty]
        public int newServicePrice { get; set; }
        [BindProperty]
        public string newServiceDescription { get; set; }
        [BindProperty]
        public int newActiveStatus { get; set; }


        [BindProperty]
        public IList<Service> Services { get; set; }

        private readonly IServiceService serviceService;

        public AdminViewServiceListModel(IServiceService _serviceService)
        {
            serviceService = _serviceService;
        }

        public void OnGet()
        {
            InitializePage();
        }

		public IActionResult OnPostCreateService()
		{
            //ModelState.Clear();
			if (!ModelState.IsValid)
			{
                InitializePage();

                ModelState.Clear();
				ModelState.AddModelError(string.Empty, "Error occurred while creating service.");
				return Page(); // Stay on the page with validation errors
			}

			try
			{
				var newService = new Service
				{
					ServiceName = newServiceName,
					Price = newServicePrice,
					ServiceDescription = newServiceDescription,
					ActiveStatus = 1
				};

				serviceService.AddService(newService);
                InitializePage();
				return Page();
			}
			catch (Exception ex)
			{
                InitializePage();
				ModelState.AddModelError(string.Empty, "Error occurred while creating service.");
				return Page(); 
			}
		}


		public IActionResult OnPostUpdateService()
        {
            Service existingService = serviceService.GetServiceById(updateServiceId);
            if (existingService == null)
            {
                ModelState.AddModelError(string.Empty, "Non-existing service");
                return RedirectToPage(); // Stay on the registration page with error message
            }

            try
            {
                // Proceed with update
                existingService.ServiceName = updateServiceName;
                existingService.Price = updateServicePrice;
                existingService.ServiceDescription = updateServiceDescription;
                existingService.ActiveStatus = updateActiveStatus;

                serviceService.UpdateService(existingService);

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating service.");
                return RedirectToPage(); // Stay on the registration page with error message
            }
        }

        private void InitializePage()
        {
			Console.WriteLine("Hohohoh");
			Services = serviceService.GetAllServices();
			Console.WriteLine("hehe");
		}
    }
}