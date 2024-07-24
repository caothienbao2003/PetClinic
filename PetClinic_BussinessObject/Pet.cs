using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicBussinessObject
{
    public partial class Pet
    {
        public Pet()
        {
            Bookings = new HashSet<Booking>();
            Hospitalizes = new HashSet<Hospitalize>();
            PetHealths = new HashSet<PetHealth>();
        }

        [Required]
        public int PetId { get; set; }
        public int? CustomerId { get; set; }
        [Required]
        public string? PetName { get; set; }
        [Required]
        [MaxLength(10)]
        public string? PetType { get; set; }
        [Range(1,20)]
        public int? PetAge { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual User? Customer { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }
        public virtual ICollection<PetHealth> PetHealths { get; set; }
    }
}
