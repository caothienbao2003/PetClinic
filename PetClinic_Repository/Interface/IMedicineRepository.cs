﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;

namespace PetClinicRepository.Interface
{
    public interface IMedicineRepository
    {
        public List<Medicine> GetMedicineList();

        public Medicine GetMedicineById(int medicineId);

        public void AddMedicine(Medicine medicine);

        public void UpdateMedicine(Medicine medicine);

        public void RemoveMedicine(int medicineId);

        public List<Medicine> GetMedicineListWithoutInclude();

        public List<Medicine> SearchMedicines(string name, int? medicineTypeId);
    }
}
