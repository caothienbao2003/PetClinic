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
	public class MedicineTypeRepository : IMedicineTypeRepository
	{
		public List<MedicineType> GetMedicineTypeList()
		{
			return MedicineTypeDAO.Instance.GetMedicineTypeList();
		}
	}
}
