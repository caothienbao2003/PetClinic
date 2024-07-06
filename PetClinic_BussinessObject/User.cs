using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Hospitalizes = new HashSet<Hospitalize>();
            Invoices = new HashSet<Invoice>();
            MedicalRecords = new HashSet<MedicalRecord>();
            Pets = new HashSet<Pet>();
            Schedules = new HashSet<Schedule>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Gender { get; set; }
        public string? DoctorRank { get; set; }
        public int? DoctorCapacity { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public int? Role { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
