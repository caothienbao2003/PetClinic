using PetClinicRepository.Interface;
using PetClinicRepository;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicServices
{
	public class MedicineTypeService : IMedicineTypeService
	{
		readonly IMedicineTypeRepository medicineTypeRepository;

		public MedicineTypeService()
		{
			if (medicineTypeRepository == null)
			{
				medicineTypeRepository = new MedicineTypeRepository();
			}
		}

		public List<MedicineType> GetMedicineTypeList()
		{
			return medicineTypeRepository.GetMedicineTypeList();
		}
	}
}
