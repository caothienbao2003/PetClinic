using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class ScheduleDAO
    {
        private readonly PetClinicContext context;

        private static ScheduleDAO instance;
        public ScheduleDAO()
        {
            context = new PetClinicContext();
        }

        public static ScheduleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScheduleDAO();
                }
                return instance;
            }
        }

        public List<Schedule> GetAllSchedule()
        {
            return context.Schedules.ToList();
        }

        public void AddSchedule(Schedule schedule)
        {
            context.Schedules.Add(schedule);
            context.SaveChanges();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            context.Schedules.Update(schedule);
            context.SaveChanges();
        }

        public List<Schedule> GetScheduleList(DateTime date, int shiftId)
        {
            return context.Schedules
                .Where(s => s.Date == date && s.ShiftId == shiftId)
                .ToList();
        }

        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId)
        {
            return context.Schedules
                .Where(s => s.Date == date && s.ShiftId == shiftId && s.ScheduleStatus == (int)ScheduleStatus.Available)
                .ToList();
        }

        public List<Schedule> GetScheduleListByDate(DateTime date)
        {
            return context.Schedules
                .Where(s => s.Date == date)
                .ToList();
        }

        public List<Schedule> GetAvailableScheduleListByDate(DateTime date)
        {
            return context.Schedules
                .Where(s => s.Date == date && s.ScheduleStatus == (int)ScheduleStatus.Available)
                .ToList();
        }
    }
}
