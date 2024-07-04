using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Medicine
    {
        public Medicine()
        {
            PrescriptionDetails = new HashSet<PrescriptionDetail>();
            VaccinationDetails = new HashSet<VaccinationDetail>();
        }

        public int MedicineId { get; set; }
        public string? MedicineName { get; set; }
        public string? MedicineUnit { get; set; }
        public string? MedicineDescription { get; set; }
        public int? MedicineTypeId { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual MedicineType? MedicineType { get; set; }
        public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual ICollection<VaccinationDetail> VaccinationDetails { get; set; }
    }
}
