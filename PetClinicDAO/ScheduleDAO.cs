using Microsoft.EntityFrameworkCore;
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
            schedule.ScheduleStatus = (int)ScheduleStatus.Available;
            schedule.NoOfOccupation = 0;

            context.Schedules.Add(schedule);
            context.SaveChanges();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            var existedSchedule = context.Schedules.FirstOrDefault(s => s.ScheduleId == schedule.ScheduleId);

            if (existedSchedule != null)
            {
                context.Entry(existedSchedule).State = EntityState.Detached;
            }

            context.Entry(schedule).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<Schedule> GetDoctorScheduleList(DateTime date, int shiftId)
        {
            return context.Schedules
                .Include(s => s.Employee)
                .Where(s => s.Date == date && s.Employee.Role == (int)UserRole.Doctor && s.ShiftId == shiftId)
                .ToList();
        }

        public List<Schedule> GetAvailableDoctorScheduleList(DateTime date, int shiftId)
        {
            return context.Schedules
                .Include(s => s.Employee)
                .Where(s => s.Date == date && s.ShiftId == shiftId && s.Employee.Role == (int)UserRole.Doctor && s.ScheduleStatus == (int)ScheduleStatus.Available)
                .ToList();
        }

        public List<Schedule> GetAvailableDoctorScheduleList(DateTime date, int shiftId, int doctorId)
        {
            return context.Schedules
                .Include(s => s.Employee)
                .Where(s => s.Date == date && s.ShiftId == shiftId && s.EmployeeId == doctorId && s.Employee.Role == (int)UserRole.Doctor && s.ScheduleStatus == (int)ScheduleStatus.Available)
                .ToList();
        }

        public Schedule GetOneScheduleByDate(DateTime date)
        {
            return context.Schedules.FirstOrDefault(s => s.Date == date);
        }

        public List<Schedule> GetByEmployeeIdBetweenDate(int employeeId, DateTime startDate, DateTime endDate)
        {
            return context.Schedules
                .Include(s => s.Employee)
                .Where(s => s.EmployeeId == employeeId && s.Date >= startDate && s.Date <= endDate)
                .ToList();
        }
    }
}
