using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IScheduleService
    {
        public List<Schedule> GetAllSchedule();
        public void AddSchedule(Schedule schedule);
        public void UpdateSchedule(Schedule schedule);
        public void GetScheduleList(DateTime date, int shiftId);
    }
}
