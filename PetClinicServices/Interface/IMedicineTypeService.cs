﻿using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{

	public interface IMedicineTypeService
	{
		public List<MedicineType> GetMedicineTypeList();

	}
}
