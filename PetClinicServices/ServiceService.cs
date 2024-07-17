using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
	public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceService()
        {
            if (serviceRepository == null)
            {
                serviceRepository = new ServiceRepository();
            }
        }
		public Service? GetServiceById(int id)
		{
			return serviceRepository.GetServiceById(id);
		}

		public List<Service> GetAllServices()
        {
            return serviceRepository.GetAllServices();
        }

        public async Task<Service> AddService(Service newService)
        {
            serviceRepository.AddService(newService);
            return newService;
        }

		public void UpdateService(Service service)
		{
			serviceRepository.UpdateService(service);
		}
	}
}
