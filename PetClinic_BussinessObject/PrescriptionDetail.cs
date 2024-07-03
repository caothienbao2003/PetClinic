using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class PrescriptionDetail
    {
        public PrescriptionDetail()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int PrescriptionDetailsId { get; set; }
        public string? PrescriptionDescription { get; set; }
        public int? Quantity { get; set; }
        public int? MedicineId { get; set; }

        public virtual Medicine? Medicine { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
