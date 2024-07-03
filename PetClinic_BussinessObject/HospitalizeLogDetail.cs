using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class HospitalizeLogDetail
    {
        public HospitalizeLogDetail()
        {
            HospitalizeLogs = new HashSet<HospitalizeLog>();
        }

        public int HospitalizeLogDetailsId { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Description { get; set; }
        public int? HospitalizeId { get; set; }

        public virtual Hospitalize? Hospitalize { get; set; }
        public virtual ICollection<HospitalizeLog> HospitalizeLogs { get; set; }
    }
}
