using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicBussinessObject
{
    public enum ActiveStatus
    {
        UnActive,
        Active
    }

    public enum UserRole
    {
        Customer,
        Staff,
        Doctor
    }

    public enum BookingStatus
    {
        Pending,
        Canceled,
        Missed,
        Completed, 
        Unconfirmed
    }

    public enum BookingPaymentStatus
    {
        Unpaid,
        Paid
    }

    public enum ShiftType
    {
        Staff,
        Doctor
    }

    public enum CageStatus
    {
        Occupied,
        Available
    }

    public enum HospitalizeStatus
    {
        Hide,
        Show
    }

    public enum VerificationStatus
    {
        Pending,
        Verified
    }

    public enum ScheduleStatus
    {
        Occupied,
        Available,
        Deleted
    }
}
