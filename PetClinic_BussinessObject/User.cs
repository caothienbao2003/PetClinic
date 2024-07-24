using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public int UserId { get; set; }
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "First name must start with a capital letter and contain only letters.")]
        public string FirstName { get; set; } = null!;
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "First name must start with a capital letter and contain only letters.")]
        public string LastName { get; set; } = null!;
        [Required]
        [RegularExpression("^[0-9]{10,12}$", ErrorMessage = "Social number must be 10 or 12 digits.")]
        public string SocialNumber { get; set; } = null!;
        [Required]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one capital letter, one number, and one special character.")]
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
