using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
	public interface IServiceService
    {
        public List<Service> GetAllServices();
		public Service? GetServiceById(int id);

		public Task<Service> AddService(Service newServices);

		public void UpdateService(Service service);
	}
}
