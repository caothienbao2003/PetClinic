﻿using PetClinicBussinessObject;
using PetClinicRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicDAO;

namespace PetClinicRepository
{
    public class ScheduleRepository : IScheduleRepository
    {
        public void AddSchedule(Schedule schedule) => ScheduleDAO.Instance.AddSchedule(schedule);

        public List<Schedule> GetAllSchedule() => ScheduleDAO.Instance.GetAllSchedule();
        public List<Schedule> GetScheduleList(DateTime date, int shiftId) => ScheduleDAO.Instance.GetScheduleList(date, shiftId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId) => ScheduleDAO.Instance.GetAvailableScheduleList(date, shiftId);
        public List<Schedule> GetAvailableScheduleList(DateTime date, int shiftId, int doctorId) => ScheduleDAO.Instance.GetAvailableScheduleList(date, shiftId, doctorId);
        public void UpdateSchedule(Schedule schedule) => ScheduleDAO.Instance.UpdateSchedule(schedule);
    }
}