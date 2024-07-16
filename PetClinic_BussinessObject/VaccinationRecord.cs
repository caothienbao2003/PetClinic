﻿using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class VaccinationRecord
    {
        public int VaccinationRecordId { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? VaccinatedAt { get; set; }
        public bool? Verification { get; set; }
        public int? PetHealthId { get; set; }
        public int? MedicineId { get; set; }

        public virtual Medicine? Medicine { get; set; }
        public virtual PetHealth? PetHealth { get; set; }
    }
}
