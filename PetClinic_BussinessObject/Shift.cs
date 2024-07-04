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
        public string? Status { get; set; }
        public string? ActiveStatus { get; set; }
        public string? Type { get; set; }

        public virtual User? Employee { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
