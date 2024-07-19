﻿using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        public List<Prescription> GetAllPrescription() => PrescriptionDAO.Instance.GetAllPrescription();

        public List<PrescriptionMedicine> GetMedicineByPrescriptionId(int id) => PrescriptionDAO.Instance.GetMedicineByPrescriptionId(id);

        public void AddPrescription(Prescription prescription) => PrescriptionDAO.Instance.AddPrescription(prescription);

        public void AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine) => PrescriptionDAO.Instance.AddPrescriptionMedicine(prescriptionMedicine);

    }
}
