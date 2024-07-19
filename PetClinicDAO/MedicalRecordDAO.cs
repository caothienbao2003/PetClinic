using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class MedicalRecordDAO
    {
        private readonly PetClinicContext context;

        private static MedicalRecordDAO? instance;

        public MedicalRecordDAO()
        {
            context = new PetClinicContext();
        }

        public static MedicalRecordDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MedicalRecordDAO();
                }
                return instance;
            }
        }

        public List<MedicalRecord> GetMedicalRecordsList()
        {
            return context.MedicalRecords.Include(b => b.Booking).Include(d => d.Doctor).Include(s => s.Service).ToList();
        }

        public MedicalRecord GetMedicalRecordByBookingId(int id)
        {
            return context.MedicalRecords.Include(b => b.Booking).Include(d => d.Doctor).Include(s => s.Service).FirstOrDefault(m => m.BookingId == id)!;
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return context.MedicalRecords.Include(b => b.Booking).Include(d => d.Doctor).Include(s => s.Service).FirstOrDefault(m => m.MedicalRecordId == id)!;
        }

        public void AddMedicalRecord(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Add(medicalRecord);
            context.SaveChanges();
        }

        public void UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Update(medicalRecord);
            context.SaveChanges();
        }
    }
}
