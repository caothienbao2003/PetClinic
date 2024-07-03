using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetClinicBussinessObject
{
    public partial class ClinicPetContext : DbContext
    {
        public ClinicPetContext()
        {
        }

        public ClinicPetContext(DbContextOptions<ClinicPetContext> options)
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
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=ClinicPet;TrustServerCertificate=True");
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
                    .HasConstraintName("FK__Bookings__Doctor__5812160E");

                entity.HasOne(d => d.DoctorShift)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DoctorShiftId)
                    .HasConstraintName("FK__Bookings__Doctor__59063A47");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Bookings__PetId__571DF1D5");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Bookings__Servic__59FA5E80");
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
                    .HasConstraintName("FK__DoctorShi__Docto__4F7CD00D");
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.Property(e => e.ShiftName).HasMaxLength(255);

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__EmployeeS__Emplo__4CA06362");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Feedbacks__Booki__5DCAEF64");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Feedbacks__Custo__5CD6CB2B");
            });

            modelBuilder.Entity<Hospitalize>(entity =>
            {
                entity.Property(e => e.InTime).HasColumnType("datetime");

                entity.Property(e => e.OutTime).HasColumnType("datetime");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK__Hospitali__CageI__6383C8BA");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Hospitali__Docto__6477ECF3");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Hospitalizes)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__Hospitali__PetId__628FA481");
            });

            modelBuilder.Entity<HospitalizeLog>(entity =>
            {
                entity.HasOne(d => d.HospitalizeLogDetails)
                    .WithMany(p => p.HospitalizeLogs)
                    .HasForeignKey(d => d.HospitalizeLogDetailsId)
                    .HasConstraintName("FK__Hospitali__Hospi__6A30C649");
            });

            modelBuilder.Entity<HospitalizeLogDetail>(entity =>
            {
                entity.HasKey(e => e.HospitalizeLogDetailsId)
                    .HasName("PK__Hospital__4AEF8CF5A706E7B9");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Hospitalize)
                    .WithMany(p => p.HospitalizeLogDetails)
                    .HasForeignKey(d => d.HospitalizeId)
                    .HasConstraintName("FK__Hospitali__Hospi__6754599E");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Invoices__Bookin__7D439ABD");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoices__Custom__7C4F7684");

                entity.HasOne(d => d.MedicalRecord)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MedicalRecordId)
                    .HasConstraintName("FK__Invoices__Medica__7E37BEF6");
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__MedicalRe__Booki__778AC167");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicalRe__Docto__787EE5A0");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicalRecords)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicalRe__Presc__797309D9");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineName).HasMaxLength(255);

                entity.Property(e => e.MedicineUnit).HasMaxLength(50);

                entity.HasOne(d => d.MedicineType)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.MedicineTypeId)
                    .HasConstraintName("FK__Medicines__Medic__6EF57B66");
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
                    .HasConstraintName("FK__Pets__CustomerId__52593CB8");
            });

            modelBuilder.Entity<PetHealth>(entity =>
            {
                entity.Property(e => e.OverallHealth).HasMaxLength(255);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WeightMeasurementDate).HasColumnType("datetime");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.PetId)
                    .HasConstraintName("FK__PetHealth__PetId__06CD04F7");

                entity.HasOne(d => d.VaccinationRecords)
                    .WithMany(p => p.PetHealths)
                    .HasForeignKey(d => d.VaccinationRecordsId)
                    .HasConstraintName("FK__PetHealth__Vacci__07C12930");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.PrescriptionDetails)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.PrescriptionDetailsId)
                    .HasConstraintName("FK__Prescript__Presc__74AE54BC");
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.HasKey(e => e.PrescriptionDetailsId)
                    .HasName("PK__Prescrip__33A5686D2EB588FE");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescript__Medic__71D1E811");
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
                    .HasName("PK__Vaccinat__AF6C0E5DC78ED3B3");

                entity.Property(e => e.NextDueDate).HasColumnType("datetime");

                entity.Property(e => e.VaccinatedAt).HasMaxLength(255);

                entity.Property(e => e.VaccinationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.VaccinationDetails)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Vaccinati__Medic__01142BA1");
            });

            modelBuilder.Entity<VaccinationRecord>(entity =>
            {
                entity.HasKey(e => e.VaccinationRecordsId)
                    .HasName("PK__Vaccinat__DA8EB31C1C9606F5");

                entity.HasOne(d => d.VaccinationDetails)
                    .WithMany(p => p.VaccinationRecords)
                    .HasForeignKey(d => d.VaccinationDetailsId)
                    .HasConstraintName("FK__Vaccinati__Vacci__03F0984C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
