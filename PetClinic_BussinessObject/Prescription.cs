using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Prescription
    {
        public Prescription()
        {
            MedicalRecords = new HashSet<MedicalRecord>();
        }

        public int PrescriptionId { get; set; }
        public int? PrescriptionDetailsId { get; set; }

        public virtual PrescriptionDetail? PrescriptionDetails { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
