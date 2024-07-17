using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PetClinicBussinessObject;
using PetClinicServices.Interface;

namespace PetClinic.Pages.Admin.AdminManageService
{
    public class AdminUpdateServiceModel : PageModel
    {
        [BindProperty]
        public int updateServiceId { get; set; }
        [BindProperty]
        public string updateServiceName { get; set; }
        [BindProperty]
        public decimal updateServicePrice { get; set; }
        [BindProperty]
        public string updateServiceDescription { get; set; }
        [BindProperty]
        public int updateActiveStatus { get; set; }

        private readonly IServiceService serviceService;

        public AdminUpdateServiceModel(IServiceService _serviceService)
        {
            serviceService = _serviceService;
        }

        public void OnGet(int serviceId)
        {
            Service existingService = serviceService.GetServiceById(serviceId);
            if (existingService != null)
            {
                updateServiceId = existingService.ServiceId;
                updateServiceName = existingService.ServiceName;
                updateServicePrice = (decimal)existingService.Price;
                updateServiceDescription = existingService.ServiceDescription;
                updateActiveStatus = (int)existingService.ActiveStatus;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Service existingService = serviceService.GetServiceById(updateServiceId);
            if (existingService == null)
            {
                ModelState.AddModelError(string.Empty, "Non-existing service");
                return Page();
            }

            try
            {
                existingService.ServiceName = updateServiceName;
                existingService.Price = updateServicePrice;
                existingService.ServiceDescription = updateServiceDescription;
                existingService.ActiveStatus = updateActiveStatus;

                serviceService.UpdateService(existingService);

                return RedirectToPage("/Admin/AdminManageService/AdminViewServiceList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error occurred while updating service.");
                return Page();
            }
        }
    }
}
