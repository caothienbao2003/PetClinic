using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class PetHealth
    {
        public int PetHealthId { get; set; }
        public string? OverallHealth { get; set; }
        public string? Conditions { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? WeightMeasurementDate { get; set; }
        public int? PetId { get; set; }
        public int? VaccinationRecordsId { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual VaccinationRecord? VaccinationRecords { get; set; }
    }
}
