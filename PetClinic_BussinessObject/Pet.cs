using System;
using System.Collections.Generic;
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

        public int PetId { get; set; }
        public int? CustomerId { get; set; }
        public string? PetName { get; set; }
        public string? PetType { get; set; }
        public int? PetAge { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual User? Customer { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }
        public virtual ICollection<PetHealth> PetHealths { get; set; }
    }
}
