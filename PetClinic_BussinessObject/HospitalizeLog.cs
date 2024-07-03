using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class HospitalizeLog
    {
        public int HospitalizeLogId { get; set; }
        public int? HospitalizeLogDetailsId { get; set; }

        public virtual HospitalizeLogDetail? HospitalizeLogDetails { get; set; }
    }
}
