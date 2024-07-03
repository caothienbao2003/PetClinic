using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class MedicineType
    {
        public MedicineType()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int MedicineTypeId { get; set; }
        public string? MedicineTypeName { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
