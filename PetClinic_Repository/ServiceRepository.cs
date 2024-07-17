using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
	public class ServiceRepository : IServiceRepository
	{
        public List<Service> GetAllServices() => ServiceDAO.Instance.GetAllServices();

        public void AddService(Service newService) => ServiceDAO.Instance.AddService(newService);

		public Service? GetServiceById(int id) => ServiceDAO.Instance.GetServiceById(id);


		public void UpdateService(Service service) => ServiceDAO.Instance.UpdateService(service);

	}
}
