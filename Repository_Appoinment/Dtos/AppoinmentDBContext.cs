
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
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"C:\\USERS\\PRANAVP3\\ONEDRIVE - CITIUSTECH\\DOCUMENTS\\PMS.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAppoinment)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK__PatientAp__patie__160F4887");
            });


            modelBuilder.Entity<Allergies>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllergyClinicalInformation)
                    .HasColumnName("allergyClinicalInformation")
                    .HasMaxLength(270)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyDescription)
                    .HasColumnName("allergyDescription")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyId)
                    .HasColumnName("allergyId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyName)
                    .HasColumnName("allergyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AllergyType)
                    .HasColumnName("allergyType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Allergies)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK__Allergies__patie__73BA3083");
            });

            modelBuilder.Entity<EmergencyContactInfo>(entity =>
            {
                entity.ToTable("emergencyContactInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.Relationship)
                    .HasColumnName("relationship")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.EmergencyContactInfo)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK__emergency__patie__74AE54BC");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

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

                entity.Property(e => e.HomeAddress)
                    .HasColumnName("homeAddress")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .HasColumnName("languages")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
