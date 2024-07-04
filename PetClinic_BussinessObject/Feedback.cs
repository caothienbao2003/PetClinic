using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? CustomerId { get; set; }
        public int? Rating { get; set; }
        public string? Description { get; set; }
        public int? BookingId { get; set; }
        public string? ActiveStatus { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual User? Customer { get; set; }
    }
}
