using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Shift
    {
        public Shift()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public string? Time { get; set; }
        public int? EmployeeId { get; set; }
        public int? NoOfOccupation { get; set; }
        public int? Status { get; set; }
        public int? ActiveStatus { get; set; }
        public int? Type { get; set; }

        public virtual User? Employee { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
