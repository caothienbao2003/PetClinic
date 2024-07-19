﻿using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IPrescriptionService
    {
        public List<Prescription> GetAllPrescription();

        public List<PrescriptionMedicine> GetMedicineByPrescriptionId(int id);

        public void AddPrescription(Prescription prescription);

        public void AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine);

    }
}
