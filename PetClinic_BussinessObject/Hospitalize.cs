using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicBussinessObject
{
    public partial class Hospitalize
    {
        public Hospitalize()
        {
            HospitalizeLogs = new HashSet<HospitalizeLog>();
        }

        public int HospitalizeId { get; set; }
        public int? PetId { get; set; }
        public int? CageId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual Cage? Cage { get; set; }
        public virtual User? Doctor { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual ICollection<HospitalizeLog> HospitalizeLogs { get; set; }
    }
}
