using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Models;

public partial class HospitallContext : DbContext
{
    public HospitallContext()
    {
    }

    public HospitallContext(DbContextOptions<HospitallContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<AdministratorPhone> AdministratorPhones { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentPhone> DepartmentPhones { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePhone> EmployeePhones { get; set; }

    public virtual DbSet<HospitalSystem> HospitalSystems { get; set; }

    public virtual DbSet<Inquiry> Inquiries { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientPhone> PatientPhones { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HP-VICTUS\\SQLEXPRESS;Database=Hospitall;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AddminId).HasName("PK__Administ__0758ACBFF67D3DAF");

            entity.ToTable("Administrator");

            entity.Property(e => e.AddminId).HasColumnName("addmin_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Passward)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("passward");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.UrlNavigation).WithMany(p => p.Administrators)
                .HasForeignKey(d => d.Url)
                .HasConstraintName("FK__Administrat__Url__4F7CD00D");
        });

        modelBuilder.Entity<AdministratorPhone>(entity =>
        {
            entity.HasKey(e => e.Phone).HasName("PK__Administ__B43B145EB3F8222B");

            entity.ToTable("Administrator_phone");

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.AddminId).HasColumnName("addmin_id");

            entity.HasOne(d => d.Addmin).WithMany(p => p.AdministratorPhones)
                .HasForeignKey(d => d.AddminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Administr__addmi__6C190EBB");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppId).HasName("PK__Appointm__6F712F9C8A0B23AF");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppId).HasColumnName("app_Id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Iddoctor).HasColumnName("iddoctor");
            entity.Property(e => e.PatId).HasColumnName("pat_id");

            entity.HasOne(d => d.IddoctorNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Iddoctor)
                .HasConstraintName("FK__Appointme__iddoc__5DCAEF64");

            entity.HasOne(d => d.Pat).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__pat_i__5CD6CB2B");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PK__Departme__BB4CBBC08A5401DE");

            entity.ToTable("Department");

            entity.HasIndex(e => e.Name, "UQ__Departme__737584F67CA9A296").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Departme__A9D10534A175F57B").IsUnique();

            entity.Property(e => e.DepId).HasColumnName("dep_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DepartmentPhone>(entity =>
        {
            entity.HasKey(e => new { e.Phone, e.DepId }).HasName("PK__Departme__AF8FDFE21301E883");

            entity.ToTable("Department_phone");

            entity.Property(e => e.Phone)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.DepId).HasColumnName("dep_ID");

            entity.HasOne(d => d.Dep).WithMany(p => p.DepartmentPhones)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__dep_I__693CA210");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__263E2DD3D98DDA23");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534D7232E3E").IsUnique();

            entity.Property(e => e.EmpId).HasColumnName("Emp_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DepId).HasColumnName("dep_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Enaple)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("D")
                .IsFixedLength()
                .HasColumnName("enaple");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JopType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("jop_Type");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Passward)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passward");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.ShiftWork)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Shift_work");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Dep).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__dep_ID__5441852A");

            entity.HasOne(d => d.UrlNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Url)
                .HasConstraintName("FK__Employee__Url__534D60F1");

            entity.HasMany(d => d.Pats).WithMany(p => p.Emps)
                .UsingEntity<Dictionary<string, object>>(
                    "ViewRecord",
                    r => r.HasOne<Patient>().WithMany()
                        .HasForeignKey("PatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__View_Reco__pat_i__66603565"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__View_Reco__Emp_i__656C112C"),
                    j =>
                    {
                        j.HasKey("EmpId", "PatId").HasName("PK__View_Rec__9C2FA336A39A257B");
                        j.ToTable("View_Record");
                        j.IndexerProperty<int>("EmpId").HasColumnName("Emp_id");
                        j.IndexerProperty<int>("PatId").HasColumnName("pat_id");
                    });
        });

        modelBuilder.Entity<EmployeePhone>(entity =>
        {
            entity.HasKey(e => new { e.Phone, e.EmpId }).HasName("PK__Employee__9658F683C2A55B4A");

            entity.ToTable("Employee_phone");

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.EmpId).HasColumnName("Emp_id");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeePhones)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee___Emp_i__6EF57B66");
        });

        modelBuilder.Entity<HospitalSystem>(entity =>
        {
            entity.HasKey(e => e.Url).HasName("PK__hospital__C5B214303C01AA2F");

            entity.ToTable("hospital_system");

            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Inquiry>(entity =>
        {
            entity.HasKey(e => e.InqId).HasName("PK__inquirie__E8BFFA6EAE4E9FB0");

            entity.ToTable("inquiries");

            entity.Property(e => e.InqId).HasColumnName("inq_id");
            entity.Property(e => e.PatId).HasColumnName("pat_id");
            entity.Property(e => e.Textinq)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("textinq");
            entity.Property(e => e.Typeinq)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeinq");

            entity.HasOne(d => d.Pat).WithMany(p => p.Inquiries)
                .HasForeignKey(d => d.PatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inquiries__pat_i__628FA481");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatId).HasName("PK__Patient__A118EE5A1DD1003D");

            entity.ToTable("Patient");

            entity.HasIndex(e => e.Email, "UQ__Patient__A9D10534696B6C54").IsUnique();

            entity.Property(e => e.PatId).HasColumnName("pat_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Enaple)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("D")
                .IsFixedLength()
                .HasColumnName("enaple");
            entity.Property(e => e.Fname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Lname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Passward)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("passward");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.UrlNavigation).WithMany(p => p.Patients)
                .HasForeignKey(d => d.Url)
                .HasConstraintName("FK__Patient__Url__59063A47");
        });

        modelBuilder.Entity<PatientPhone>(entity =>
        {
            entity.HasKey(e => new { e.Phone, e.PatId }).HasName("PK__Patient___0E2A9ABBF4E9AFF7");

            entity.ToTable("Patient_phone");

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.PatId).HasColumnName("pat_id");

            entity.HasOne(d => d.Pat).WithMany(p => p.PatientPhones)
                .HasForeignKey(d => d.PatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Patient_p__pat_i__71D1E811");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Rid);

            entity.ToTable("Record");

            entity.Property(e => e.Rid).HasColumnName("RID");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("diagnosis");
            entity.Property(e => e.Medications)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("medications");
            entity.Property(e => e.PatId).HasColumnName("pat_id");
            entity.Property(e => e.PatientMedical)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("patient_medical");
            entity.Property(e => e.Prescriptions)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("prescriptions");
            entity.Property(e => e.TestResults)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("_test_results");
            entity.Property(e => e.TreatmentAdministered)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("treatment_administered");
            entity.Property(e => e.TreatmentPlans)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("treatment_plans");
            entity.Property(e => e.Vitals)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("vitals");

            entity.HasOne(d => d.Pat).WithMany(p => p.Records)
                .HasForeignKey(d => d.PatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Record__pat_id__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
