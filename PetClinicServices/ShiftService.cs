using PetClinicBussinessObject;
using PetClinicDAO;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices
{
    public class ShiftService : IShiftService
    {
        private IShiftRepository shiftRepo;
        public ShiftService()
        {
            if (shiftRepo == null)
            {
                shiftRepo = new ShiftRepository();
            }
        }
        public List<Shift> GetAllShifts() => shiftRepo.GetAllShifts();
    }
}
