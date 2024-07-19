using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
	public interface IServiceRepository
    {
        public List<Service> GetAllServices();

		public Service? GetServiceById(int id);

		public void AddService(Service newService);

		public void UpdateService(Service service);

	}
}
