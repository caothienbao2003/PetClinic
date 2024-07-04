using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Cage
    {
        public Cage()
        {
            Hospitalizes = new HashSet<Hospitalize>();
        }

        public int CageId { get; set; }
        public string? Status { get; set; }
        public string? ActiveStatus { get; set; }

        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }
    }
}
