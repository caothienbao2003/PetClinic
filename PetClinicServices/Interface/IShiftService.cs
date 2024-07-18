using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IShiftService
    {
        public List<Shift> GetAllShifts();
        public List<Shift> GetAllDoctorShifts();
        public List<Shift> GetAllStaffShifts();
        public Shift GetShiftById(int shiftId);
    }
}
