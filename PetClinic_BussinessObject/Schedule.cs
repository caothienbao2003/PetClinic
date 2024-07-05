using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ScheduleId { get; set; }
        public DateTime? Date { get; set; }
        public int? ShiftId { get; set; }
        public int? EmployeeId { get; set; }
        public int? NoOfOccupation { get; set; }
        public int? ScheduleStatus { get; set; }

        public virtual User? Employee { get; set; }
        public virtual Shift? Shift { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
