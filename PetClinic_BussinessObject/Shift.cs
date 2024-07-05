using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Shift
    {
        public Shift()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? ActiveStatus { get; set; }
        public int? ShiftType { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
