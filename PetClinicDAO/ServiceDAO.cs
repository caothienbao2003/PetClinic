using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
	public class ServiceDAO
    {
		private readonly PetClinicContext context;

		private static ServiceDAO? instance;

		public ServiceDAO()
		{
			context = new PetClinicContext();
		}

		public static ServiceDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ServiceDAO();
				}
				return instance;
			}
		}

		public Service? GetServiceById(int id)
		{
			return context.Services.Find(id);
		}

		public List<Service> GetAllServices() => context.Services.ToList();

        public void AddService(Service newService)
        {
            try
            {
                context.Services.Add(newService);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add new service.", ex);
            }
        }

		public void UpdateService(Service service)
		{
			try
			{
				context.Services.Update(service);
				context.SaveChanges();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to update service.", ex);
			}
		}

	}
}
