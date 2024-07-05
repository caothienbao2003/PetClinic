using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class MedicalRecord
    {
        public int MedicalRecordId { get; set; }
        public string? MedicalRecordDescription { get; set; }
        public int? BookingId { get; set; }
        public int? DoctorId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual User? Doctor { get; set; }
        public virtual Prescription? Prescription { get; set; }
        public virtual Service? Service { get; set; }
    }
}
