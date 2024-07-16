using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class RecordMedicine
    {
        public int VaccinationRecordId { get; set; }
        public int MedicineId { get; set; }
        public int? MedicineQuantity { get; set; }

        public virtual Medicine Medicine { get; set; } = null!;
        public virtual VaccinationRecord VaccinationRecord { get; set; } = null!;
    }
}
