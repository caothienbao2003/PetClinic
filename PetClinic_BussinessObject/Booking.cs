using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Booking
    {
        public Booking()
        {
            Feedbacks = new HashSet<Feedback>();
            Invoices = new HashSet<Invoice>();
            MedicalRecords = new HashSet<MedicalRecord>();
        }

        public int BookingId { get; set; }
        public int? PetId { get; set; }
        public int? DoctorId { get; set; }
        public int? ShiftId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Status { get; set; }

        public virtual User? Doctor { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual Service? Service { get; set; }
        public virtual Shift? Shift { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
