using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class DoctorShift
    {
        public DoctorShift()
        {
            Bookings = new HashSet<Booking>();
        }

        public int DoctorShiftId { get; set; }
        public string? ShiftName { get; set; }
        public string? Time { get; set; }
        public int? NoOfOccupation { get; set; }
        public int? DoctorId { get; set; }
        public string? Status { get; set; }
        public int? EmployeeShiftId { get; set; }

        public virtual User? Doctor { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
