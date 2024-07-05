using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class HospitalizeLog
    {
        public int HospitalizeLogId { get; set; }
        public int? HospitalizeId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Description { get; set; }
        public int? ActiveStatus { get; set; }

        public virtual Hospitalize? Hospitalize { get; set; }
    }
}
