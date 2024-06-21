using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Emias_WPF.Models
{
    public partial class UMIASContext : DbContext
    {
        public UMIASContext()
        {
        }

        public UMIASContext(DbContextOptions<UMIASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<AnalyseDocument> AnalyseDocuments { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; } = null!;
        public virtual DbSet<Direction> Directions { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Admins__4C3F97F4951FB0B4");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(50)
                    .HasColumnName("Admin_Name");

                entity.Property(e => e.EnterPassword).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<AnalyseDocument>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__AnalyseD__ECE24AABE74266EE");

                entity.ToTable("AnalyseDocument");

                entity.Property(e => e.IdAppointment).ValueGeneratedNever();

            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__ECE24AABFA8CC8AB");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.Oms).HasColumnName("OMS");

            });

            modelBuilder.Entity<AppointmentDocument>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__ECE24AAB44894806");

                entity.ToTable("AppointmentDocument");

                entity.Property(e => e.IdAppointment).ValueGeneratedNever();

            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.HasKey(e => e.IdDirection)
                    .HasName("PK__Directio__7780E2B2A316062C");

                entity.Property(e => e.IdDirection)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oms).HasColumnName("OMS");

            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("PK__Doctor__F838DB3E476D322F");

                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorName)
                    .HasMaxLength(50)
                    .HasColumnName("Doctor_Name");

                entity.Property(e => e.EnterPassword).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.WorkAddress).HasMaxLength(50);


            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Oms)
                    .HasName("PK__Patient__CB396B8BEBD0B611");

                entity.ToTable("Patient");

                entity.Property(e => e.Oms)
                    .ValueGeneratedNever()
                    .HasColumnName("OMS");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LivingAddress).HasMaxLength(255);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(255)
                    .HasColumnName("Patient_Address");

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .HasColumnName("Patient_Name");

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(18);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<ResearchDocument>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Research__ECE24AAB45D231E8");

                entity.ToTable("ResearchDocument");

                entity.Property(e => e.IdAppointment).ValueGeneratedNever();


            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.IdSpeciality)
                    .HasName("PK__Speciali__5C8D4E68B7D09CC0");

                entity.Property(e => e.SpecialityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Speciality_Name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Statuses__B450643A31F79EA0");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("Status_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
