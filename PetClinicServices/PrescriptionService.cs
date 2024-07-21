using PetClinicRepository.Interface;
using PetClinicRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicServices.Interface;
using PetClinicBussinessObject;

namespace PetClinicServices
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository prescriptionRepository;

        public PrescriptionService()
        {
            if (prescriptionRepository == null)
            {
                prescriptionRepository = new PrescriptionRepository();
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            prescriptionRepository.AddPrescription(prescription);
        }

        public void AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
        {
            prescriptionRepository.AddPrescriptionMedicine(prescriptionMedicine);
        }

        public Prescription GetPrescriptionByMedicalRecordId(int id)
        {
            return prescriptionRepository.GetPrescriptionByMedicalRecordId(id);
        }

        public List<Prescription> GetAllPrescription()
        {
            return prescriptionRepository.GetAllPrescription();
        }

        public List<PrescriptionMedicine> GetMedicineByPrescriptionId(int id)
        {
            return prescriptionRepository.GetMedicineByPrescriptionId(id);
        }

        public void UpdatePrescription(Prescription prescription)
        {
            prescriptionRepository.UpdatePrescription(prescription);
        }

        public void UpdatePrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
        {
            prescriptionRepository.UpdatePrescriptionMedicine(prescriptionMedicine);
        }
    }
}
