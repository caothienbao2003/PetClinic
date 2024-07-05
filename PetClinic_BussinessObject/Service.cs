using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
            MedicalRecords = new HashSet<MedicalRecord>();
        }

        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? Price { get; set; }
        public string? ServiceDescription { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
