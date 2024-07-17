using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Prescription
    {
        public Prescription()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
        }

        public int PrescriptionId { get; set; }
        public int? MedicalRecordId { get; set; }

        public virtual MedicalRecord? MedicalRecord { get; set; }
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
