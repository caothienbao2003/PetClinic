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
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; } = null!;
        public virtual DbSet<RecordMedicine> RecordMedicines { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VaccinationRecord> VaccinationRecords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json", true, true).Build();
                var connectionString = config.GetConnectionString("PetClinic");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingAt).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Booking__DoctorI__34C8D9D1");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Booking__PetId__33D4B598");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__Booking__Schedul__35BCFE0A");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Booking__Service__36B12243");
            });

            modelBuilder.Entity<Cage>(entity =>
            {
                entity.ToTable("Cage");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Feedback__Bookin__398D8EEE");
            });

            modelBuilder.Entity<Hospitalize>(entity =>
            {
                entity.ToTable("Hospitalize");

                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK__Hospitali__CageI__3F466844");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Hospitali__Docto__403A8C7D");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Hospitali__PetId__3E52440B");
            });

            modelBuilder.Entity<HospitalizeLog>(entity =>
            {
                entity.ToTable("HospitalizeLog");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Hospitalize)
                    .WithMany(p => p.HospitalizeLogs)
                    .HasForeignKey(d => d.HospitalizeId)
                    .HasConstraintName("FK__Hospitali__Hospi__4316F928");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Invoice__Booking__571DF1D5");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoice__Custome__5629CD9C");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecord");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__MedicalRe__Booki__45F365D3");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicalRe__Docto__46E78A0C");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__MedicalRe__Servi__47DBAE45");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.MedicineName).HasMaxLength(255);

                entity.HasOne(d => d.MedicineType)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.MedicineTypeId)
                    .HasConstraintName("FK__Medicine__Medici__4F7CD00D");
            });

            modelBuilder.Entity<MedicineType>(entity =>
            {
                entity.ToTable("MedicineType");

                entity.Property(e => e.MedicineTypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.PetName).HasMaxLength(255);

                entity.Property(e => e.PetType).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Pet__CustomerId__2C3393D0");
            });

            modelBuilder.Entity<PetHealth>(entity =>
            {
                entity.ToTable("PetHealth");

                entity.Property(e => e.OverallHealth).HasMaxLength(255);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightMeasurementDate).HasColumnType("datetime");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__PetHealth__PetId__2F10007B");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescription");

                entity.HasOne(d => d.MedicalRecord)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.MedicalRecordId)
                    .HasConstraintName("FK__Prescript__Medic__4CA06362");
            });

            modelBuilder.Entity<PrescriptionMedicine>(entity =>
            {
                entity.HasKey(e => new { e.PrescriptionId, e.MedicineId })
                    .HasName("PK__Prescrip__54E11ABBD22C9C61");

                entity.ToTable("Prescription_Medicine");

                entity.Property(e => e.Dosage).HasMaxLength(255);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Medic__534D60F1");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionMedicines)
                    .HasForeignKey(d => d.PrescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prescript__Presc__52593CB8");
            });

            modelBuilder.Entity<RecordMedicine>(entity =>
            {
                entity.HasKey(e => new { e.VaccinationRecordId, e.MedicineId })
                    .HasName("PK__Record_M__BA0085F5645FD658");

                entity.ToTable("Record_Medicine");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.RecordMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Record_Me__Medic__5DCAEF64");

                entity.HasOne(d => d.VaccinationRecord)
                    .WithMany(p => p.RecordMedicines)
                    .HasForeignKey(d => d.VaccinationRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Record_Me__Vacci__5CD6CB2B");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Schedule__Employ__29572725");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Schedule__ShiftI__286302EC");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceName).HasMaxLength(255);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.ShiftName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.DoctorRank).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.SocialNumber).HasMaxLength(12);
            });

            modelBuilder.Entity<VaccinationRecord>(entity =>
            {
                entity.ToTable("VaccinationRecord");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.VaccinatedAt).HasMaxLength(255);

                entity.Property(e => e.VaccinationDate).HasColumnType("datetime");

                entity.HasOne(d => d.PetHealth)
                    .WithMany(p => p.VaccinationRecords)
                    .HasForeignKey(d => d.PetHealthId)
                    .HasConstraintName("FK__Vaccinati__PetHe__59FA5E80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
