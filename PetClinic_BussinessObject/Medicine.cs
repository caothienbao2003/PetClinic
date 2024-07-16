using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescriptionMedicines = new HashSet<PrescriptionMedicine>();
            RecordMedicines = new HashSet<RecordMedicine>();
        }

        public int MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public string? MedicineDescription { get; set; }
        public int? MedicineTypeId { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual MedicineType? MedicineType { get; set; }
        public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public virtual ICollection<RecordMedicine> RecordMedicines { get; set; }
    }
}
