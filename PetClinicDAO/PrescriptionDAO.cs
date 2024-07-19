using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class PrescriptionDAO
    {
        private readonly PetClinicContext context;

        private static PrescriptionDAO? instance;

        public PrescriptionDAO()
        {
            context = new PetClinicContext();
        }

        public static PrescriptionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrescriptionDAO();
                }
                return instance;
            }
        }

        public List<Prescription> GetAllPrescription()
        {
            return context.Prescriptions.ToList();
        }

        public List<PrescriptionMedicine> GetMedicineByPrescriptionId(int id)
        {
            return context.PrescriptionMedicines.Where(p => p.PrescriptionId == id).ToList();
        }

        public void AddPrescription(Prescription prescription)
        {
            context.Prescriptions.Add(prescription);
            context.SaveChanges();
        }

        public void AddPrescriptionMedicine(PrescriptionMedicine prescriptionMedicine)
        {
            context.PrescriptionMedicines.Add(prescriptionMedicine);
            context.SaveChanges();
        }
    }
}
