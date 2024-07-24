using PetClinicBussinessObject;
using PetClinicDAO;
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
        public List<Schedule> GetScheduleList(DateTime date, int shiftId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId, int doctorId);
        public List<Schedule> GetByEmployeeIdBetweenDate(int employeeId, DateTime startDate, DateTime endDate);
        public int GetRandomScheduleIdFromScheduleList(List<Schedule> scheduleList);
        public void DeleteSchedule(Schedule schedule);
        public Schedule GetById(int id);
    }
}
