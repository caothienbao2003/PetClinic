using System;
using System.Collections.Generic;

namespace PetClinicBussinessObject
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Total { get; set; }
        public int? BookingId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual User? Customer { get; set; }
    }
}
