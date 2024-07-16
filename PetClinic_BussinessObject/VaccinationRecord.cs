using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class VaccinationRecord
    {
        public VaccinationRecord()
        {
            RecordMedicines = new HashSet<RecordMedicine>();
        }

        public int VaccinationRecordId { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? VaccinatedAt { get; set; }
        public bool? Verification { get; set; }
        public int? PetHealthId { get; set; }

        public virtual PetHealth? PetHealth { get; set; }
        public virtual ICollection<RecordMedicine> RecordMedicines { get; set; }
    }
}
