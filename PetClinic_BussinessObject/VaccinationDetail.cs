using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class VaccinationDetail
    {
        public VaccinationDetail()
        {
            VaccinationRecords = new HashSet<VaccinationRecord>();
        }

        public int VaccinationDetailsId { get; set; }
        public int? MedicineId { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? VaccinatedAt { get; set; }
        public bool? Verification { get; set; }

        public virtual Medicine? Medicine { get; set; }
        public virtual ICollection<VaccinationRecord> VaccinationRecords { get; set; }
    }
}
