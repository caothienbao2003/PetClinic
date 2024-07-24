using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinicBussinessObject
{
    public partial class PetHealth
    {
        public PetHealth()
        {
            VaccinationRecords = new HashSet<VaccinationRecord>();
        }

        [Required]
        public int PetHealthId { get; set; }
        public string? OverallHealth { get; set; }
        public string? Conditions { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? WeightMeasurementDate { get; set; }
        public int? PetId { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual ICollection<VaccinationRecord> VaccinationRecords { get; set; }
    }
}
