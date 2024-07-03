using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class VaccinationRecord
    {
        public VaccinationRecord()
        {
            PetHealths = new HashSet<PetHealth>();
        }

        public int VaccinationRecordsId { get; set; }
        public int? VaccinationDetailsId { get; set; }

        public virtual VaccinationDetail? VaccinationDetails { get; set; }
        public virtual ICollection<PetHealth> PetHealths { get; set; }
    }
}
