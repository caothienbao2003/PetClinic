using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicRepository.Interface
{
    public interface IScheduleRepository
    {
        public List<Schedule> GetAllSchedule();
        public void AddSchedule(Schedule schedule);
        public void UpdateSchedule(Schedule schedule);
        public void GetScheduleList(DateTime date, int shiftId);
    }
}
