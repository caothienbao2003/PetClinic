using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class ShiftDAO
    {
        private readonly PetClinicContext context;

        private static ShiftDAO? instance;

        public ShiftDAO()
        {
            context = new PetClinicContext();
        }

        public static ShiftDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftDAO();
                }
                return instance;
            }
        }

        public List<Shift> GetAllShifts()
        {
            return context.Shifts.ToList();
        }

        public void AddShift(Shift shift)
        {
            context.Shifts.Add(shift);
            context.SaveChanges();
        }

        public void UpdateShift(Shift shift)
        {
            context.Shifts.Update(shift);
            context.SaveChanges();
        }

        public void DeleteShift(Shift shift)
        {
            context.Shifts.Remove(shift);
            context.SaveChanges();
        }
    }
}