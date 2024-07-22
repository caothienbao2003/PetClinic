using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
	public class MedicineTypeDAO
	{
		private readonly PetClinicContext context;

		private static MedicineTypeDAO? instance;

		public MedicineTypeDAO()
		{
			context = new PetClinicContext();
		}

		public static MedicineTypeDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MedicineTypeDAO();
				}
				return instance;
			}
		}

		public List<MedicineType> GetMedicineTypeList()
		{
			return context.MedicineTypes.ToList();
		}
	}
}
