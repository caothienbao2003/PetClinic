using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<DoctorShift> DoctorShifts { get; set; } = null!;
        public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Hospitalize> Hospitalizes { get; set; } = null!;
        public virtual DbSet<HospitalizeLog> HospitalizeLogs { get; set; } = null!;
        public virtual DbSet<HospitalizeLogDetail> HospitalizeLogDetails { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<MedicineType> MedicineTypes { get; set; } = null!;
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<PetHealth> PetHealths { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VaccinationDetail> VaccinationDetails { get; set; } = null!;
        public virtual DbSet<VaccinationRecord> VaccinationRecords { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=PetClinic;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Bookings__Doctor__32E0915F");

                entity.HasOne(d => d.DoctorShift)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorShiftId)
                    .HasConstraintName("FK__Bookings__Doctor__33D4B598");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Bookings__PetId__31EC6D26");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Bookings__Servic__34C8D9D1");
            });

            modelBuilder.Entity<Cage>(entity =>
            {
                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<DoctorShift>(entity =>
            {
                entity.Property(e => e.ShiftName).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorShifts)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__DoctorShi__Docto__2A4B4B5E");
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.Property(e => e.ShiftName).HasMaxLength(255);

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeS__Emplo__276EDEB3");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Feedbacks__Booki__38996AB5");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Feedbacks__Custo__37A5467C");
            });

            modelBuilder.Entity<Hospitalize>(entity =>
            {
                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK__Hospitali__CageI__3E52440B");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Hospitali__Docto__3F466844");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Hospitali__PetId__3D5E1FD2");
            });

            modelBuilder.Entity<HospitalizeLog>(entity =>
            {
                entity.HasOne(d => d.HospitalizeLogDetails)
                    .WithMany(p => p.HospitalizeLogs)
                    .HasForeignKey(d => d.HospitalizeLogDetailsId)
                    .HasConstraintName("FK__Hospitali__Hospi__44FF419A");
            });

            modelBuilder.Entity<HospitalizeLogDetail>(entity =>
            {
                entity.HasKey(e => e.HospitalizeLogDetailsId)
                    .HasName("PK__Hospital__4AEF8CF5F4208D68");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Hospitalize)
                    .WithMany(p => p.HospitalizeLogDetails)
                    .HasForeignKey(d => d.HospitalizeId)
                    .HasConstraintName("FK__Hospitali__Hospi__4222D4EF");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Invoices__Bookin__5812160E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoices__Custom__571DF1D5");

                entity.HasOne(d => d.MedicalRecord)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MedicalRecordId)
                    .HasConstraintName("FK__Invoices__Medica__59063A47");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__MedicalRe__Booki__52593CB8");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicalRe__Docto__534D60F1");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicalRe__Presc__5441852A");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineName).HasMaxLength(255);

                entity.Property(e => e.MedicineUnit).HasMaxLength(50);

                entity.HasOne(d => d.MedicineType)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.MedicineTypeId)
                    .HasConstraintName("FK__Medicines__Medic__49C3F6B7");
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
                    .HasConstraintName("FK__Pets__CustomerId__2D27B809");
            });

            modelBuilder.Entity<PetHealth>(entity =>
            {
                entity.Property(e => e.OverallHealth).HasMaxLength(255);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightMeasurementDate).HasColumnType("datetime");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__PetHealth__PetId__619B8048");

                entity.HasOne(d => d.VaccinationRecords)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.VaccinationRecordsId)
                    .HasConstraintName("FK__PetHealth__Vacci__628FA481");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.PrescriptionDetails)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PrescriptionDetailsId)
                    .HasConstraintName("FK__Prescript__Presc__4F7CD00D");
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.HasKey(e => e.PrescriptionDetailsId)
                    .HasName("PK__Prescrip__33A5686D7459C451");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescript__Medic__4CA06362");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceName).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Rank).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<VaccinationDetail>(entity =>
            {
                entity.HasKey(e => e.VaccinationDetailsId)
                    .HasName("PK__Vaccinat__AF6C0E5D62AD7D7C");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.VaccinatedAt).HasMaxLength(255);

                entity.Property(e => e.VaccinationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.VaccinationDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Vaccinati__Medic__5BE2A6F2");
            });

            modelBuilder.Entity<VaccinationRecord>(entity =>
            {
                entity.HasKey(e => e.VaccinationRecordsId)
                    .HasName("PK__Vaccinat__DA8EB31C864CC7D6");

                entity.HasOne(d => d.VaccinationDetails)
                    .WithMany(p => p.VaccinationRecords)
                    .HasForeignKey(d => d.VaccinationDetailsId)
                    .HasConstraintName("FK__Vaccinati__Vacci__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
