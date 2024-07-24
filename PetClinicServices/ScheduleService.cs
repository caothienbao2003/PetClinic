using PetClinicBussinessObject;
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
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository scheduleRepository;

        public ScheduleService()
        {
            scheduleRepository = new ScheduleRepository();
        }

        public void AddSchedule(Schedule schedule) => scheduleRepository.AddSchedule(schedule);

        public List<Schedule> GetAllSchedule() => scheduleRepository.GetAllSchedule();

        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId) => scheduleRepository.GetAvailableScheduleList(date, shiftId);

        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId, int doctorId) => scheduleRepository.GetAvailableScheduleList(date, shiftId, doctorId);
        public List<Schedule> GetScheduleList(DateTime date, int shiftId) => scheduleRepository.GetScheduleList(date, shiftId);
        public void UpdateSchedule(Schedule schedule) => scheduleRepository.UpdateSchedule(schedule);
        public List<Schedule> GetByEmployeeIdBetweenDate(int employeeId, DateTime startDate, DateTime endDate) => scheduleRepository.GetByEmployeeIdBetweenDate(employeeId, startDate, endDate);
        public int GetRandomScheduleIdFromScheduleList(List<Schedule> scheduleList)
        {
            int count = 0;
            List<int> scheduleIdList = new List<int>();
            foreach (Schedule schedule in scheduleList)
            {
                count++;
                scheduleIdList.Add(schedule.ScheduleId);
            }

            Random random = new Random();
            int index = random.Next(count);
            return scheduleIdList[index];
        }
    }
}
