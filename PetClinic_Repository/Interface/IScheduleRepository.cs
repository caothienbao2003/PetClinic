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
        public List<Schedule> GetScheduleList(DateTime date, int shiftId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId, int doctorId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId);
        public List<Schedule> GetByEmployeeIdBetweenDate(int employeeId, DateTime startDate, DateTime endDate);
        public void DeleteSchedule(Schedule schedule);
        public Schedule GetById(int id);
    }
}
