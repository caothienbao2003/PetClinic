using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            DoctorShifts = new HashSet<DoctorShift>();
            EmployeeShifts = new HashSet<EmployeeShift>();
            Feedbacks = new HashSet<Feedback>();
            Hospitalizes = new HashSet<Hospitalize>();
            Invoices = new HashSet<Invoice>();
            MedicalRecords = new HashSet<MedicalRecord>();
            Pets = new HashSet<Pet>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Gender { get; set; }
        public string? Rank { get; set; }
        public int? DoctorCapacity { get; set; }
        public decimal? Salary { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<DoctorShift> DoctorShifts { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
