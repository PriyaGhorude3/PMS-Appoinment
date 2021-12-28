using Appoinment_Booking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Appoinment.Dtos
{
    public partial class AppoinmentDBContext : DbContext
    {
        public AppoinmentDBContext()
        {
        }

        public AppoinmentDBContext(DbContextOptions<AppoinmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PatientAppoinment> PatientAppoinment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientAppoinment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.AppoinmentDate)
                    .HasColumnName("appoinment_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AppoinmentTime).HasColumnName("appoinment_time");

                entity.Property(e => e.AppoinmentType)
                    .HasColumnName("appoinment_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.Physicianname)
                    .HasColumnName("physicianname")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
