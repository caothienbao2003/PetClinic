using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class PrescriptionMedicine
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public int? MedicineQuantity { get; set; }
        public string? Dosage { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual Prescription Prescription { get; set; } = null!;
    }
}
