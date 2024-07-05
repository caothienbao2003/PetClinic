using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicBussinessObject
{
    public partial class Cage
    {
        public Cage()
        {
            Hospitalizes = new HashSet<Hospitalize>();
        }

        public int CageId { get; set; }
        public int? CageStatus { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual ICollection<Hospitalize> Hospitalizes { get; set; }

        [NotMapped]
        public CageStatus? CageEnumStatus
        {
            get { return (CageStatus?)CageStatus; }
            set { CageStatus = (int?)value; }
        }

        [NotMapped]
        public ActiveStatus? ActiveEnumStatus
        {
            get { return (ActiveStatus?)ActiveStatus; }
            set { ActiveStatus = (int?)value; }
        }
    }
}
