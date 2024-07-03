using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class EmployeeShift
    {
        public int EmployeeShiftId { get; set; }
        public string? ShiftName { get; set; }
        public string? Time { get; set; }
        public int? EmployeeId { get; set; }
        public int? ShiftId { get; set; }

        public virtual User? Employee { get; set; }
    }
}
