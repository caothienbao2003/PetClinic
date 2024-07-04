using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicBussinessObject
{
	public enum ActiveStatus
	{
		Active,
		InActive
	}

    public enum BookingStatus
	{
		Confirmed,
		Pending
	}

	public enum BookingPaymentStatus
	{
		Paid,
		Unpaid
	}

	public enum CageStatus
    {
        Available,
        Occupied
    }
}
