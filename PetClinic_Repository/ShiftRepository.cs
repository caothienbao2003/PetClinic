using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository
{
    public class ShiftRepository : IShiftRepository
    {
        public List<Shift> GetAllShifts() => ShiftDAO.Instance.GetAllShifts();
        public List<Shift> GetAllDoctorShifts() => ShiftDAO.Instance.GetAllShiftWithShiftType(ShiftType.Doctor);
        public List<Shift> GetAllStaffShifts() => ShiftDAO.Instance.GetAllShiftWithShiftType(ShiftType.Staff);
    }
}
