using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PetClinicBussinessObject
{
    public partial class PetClinicContext : DbContext
    {
        public PetClinicContext()
        {
        }

        public PetClinicContext(DbContextOptions<PetClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cage> Cages { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Hospitalize> Hospitalizes { get; set; } = null!;
        public virtual DbSet<HospitalizeLog> HospitalizeLogs { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<MedicineType> MedicineTypes { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<PetHealth> PetHealths { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VaccinationDetail> VaccinationDetails { get; set; } = null!;
        public virtual DbSet<VaccinationRecord> VaccinationRecords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            var strConnection = config.GetConnectionString("PetClinic");
            return strConnection;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingAt).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Bookings__Doctor__31EC6D26");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Bookings__PetId__30F848ED");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__Bookings__Schedu__32E0915F");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Bookings__Servic__33D4B598");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Feedbacks__Booki__36B12243");
            });

            modelBuilder.Entity<Hospitalize>(entity =>
            {
                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK__Hospitali__CageI__3C69FB99");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Hospitali__Docto__3D5E1FD2");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Hospitali__PetId__3B75D760");
            });

            modelBuilder.Entity<HospitalizeLog>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Hospitalize)
                    .WithMany(p => p.HospitalizeLogs)
                    .HasForeignKey(d => d.HospitalizeId)
                    .HasConstraintName("FK__Hospitali__Hospi__403A8C7D");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Invoices__Bookin__5441852A");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoices__Custom__534D60F1");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__MedicalRe__Booki__4D94879B");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicalRe__Docto__4E88ABD4");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicalRe__Presc__4F7CD00D");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__MedicalRe__Servi__5070F446");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineName).HasMaxLength(255);

                entity.HasOne(d => d.MedicineType)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.MedicineTypeId)
                    .HasConstraintName("FK__Medicines__Medic__44FF419A");
            });

            modelBuilder.Entity<MedicineType>(entity =>
            {
                entity.Property(e => e.MedicineTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.PetName).HasMaxLength(255);

                entity.Property(e => e.PetType).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Pets__CustomerId__2C3393D0");
            });

            modelBuilder.Entity<PetHealth>(entity =>
            {
                entity.Property(e => e.OverallHealth).HasMaxLength(255);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightMeasurementDate).HasColumnType("datetime");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__PetHealth__PetId__5CD6CB2B");

                entity.HasOne(d => d.VaccinationRecords)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.VaccinationRecordsId)
                    .HasConstraintName("FK__PetHealth__Vacci__5DCAEF64");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.PrescriptionDetails)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PrescriptionDetailsId)
                    .HasConstraintName("FK__Prescript__Presc__4AB81AF0");
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.HasKey(e => e.PrescriptionDetailsId)
                    .HasName("PK__Prescrip__33A5686D5DADB250");

                entity.Property(e => e.MedicineUnit).HasMaxLength(50);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescript__Medic__47DBAE45");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Schedules__Emplo__29572725");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Schedules__Shift__286302EC");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceName).HasMaxLength(255);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.DoctorRank).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<VaccinationDetail>(entity =>
            {
                entity.HasKey(e => e.VaccinationDetailsId)
                    .HasName("PK__Vaccinat__AF6C0E5D5CE03700");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.VaccinatedAt).HasMaxLength(255);

                entity.Property(e => e.VaccinationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.VaccinationDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Vaccinati__Medic__571DF1D5");
            });

            modelBuilder.Entity<VaccinationRecord>(entity =>
            {
                entity.HasKey(e => e.VaccinationRecordsId)
                    .HasName("PK__Vaccinat__DA8EB31CDC95033B");

                entity.HasOne(d => d.VaccinationDetails)
                    .WithMany(p => p.VaccinationRecords)
                    .HasForeignKey(d => d.VaccinationDetailsId)
                    .HasConstraintName("FK__Vaccinati__Vacci__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
