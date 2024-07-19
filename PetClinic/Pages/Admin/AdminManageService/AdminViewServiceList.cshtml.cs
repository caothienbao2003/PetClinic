using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PetClinicBussinessObject;
using PetClinicServices.Interface;
using System.Collections.Generic;

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

        private void InitializePage()
        {
            Services = serviceService.GetAllServices();
        }
    }
}
