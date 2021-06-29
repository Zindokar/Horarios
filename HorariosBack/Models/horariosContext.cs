using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace HorariosBack.Models
{
  public partial class horariosContext : DbContext
  {
    private readonly IConfiguration _config;

    public horariosContext(IConfiguration config)
    {
      _config = config;
    }

    public horariosContext(DbContextOptions<horariosContext> options, IConfiguration config)
        : base(options)
    {
      _config = config;
    }

    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<CompanyAudit> CompanyAudits { get; set; }
    public virtual DbSet<JobContract> JobContracts { get; set; }
    public virtual DbSet<JobContractAudit> JobContractAudits { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<PersonAudit> PersonAudits { get; set; }
    public virtual DbSet<Schedule> Schedules { get; set; }
    public virtual DbSet<ScheduleAudit> ScheduleAudits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseMySql(_config.GetSection("Auth")["ConnectionString"], Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasCharSet("utf8mb4")
          .UseCollation("utf8mb4_0900_ai_ci");

      modelBuilder.Entity<Company>(entity =>
      {
        entity.ToTable("Company");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("name");
      });

      modelBuilder.Entity<CompanyAudit>(entity =>
      {
        entity.ToTable("CompanyAudit");

        entity.HasIndex(e => e.Company, "company");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.ChangedDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("changedDate");

        entity.Property(e => e.Company).HasColumnName("company");

        entity.Property(e => e.CurrentName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("currentName");

        entity.Property(e => e.PreviousName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("previousName");

        entity.HasOne(d => d.CompanyNavigation)
                  .WithMany(p => p.CompanyAudits)
                  .HasForeignKey(d => d.Company)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("CompanyAudit_ibfk_1");
      });

      modelBuilder.Entity<JobContract>(entity =>
      {
        entity.HasKey(e => new { e.Person, e.Company })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("JobContract");

        entity.HasIndex(e => e.Company, "company");

        entity.Property(e => e.Person).HasColumnName("person");

        entity.Property(e => e.Company).HasColumnName("company");

        entity.Property(e => e.FinishDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("finishDate");

        entity.Property(e => e.Position)
                  .HasMaxLength(255)
                  .HasColumnName("position");

        entity.Property(e => e.SalaryPerHour).HasColumnName("salaryPerHour");

        entity.Property(e => e.StartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("startDate");

        entity.HasOne(d => d.CompanyNavigation)
                  .WithMany(p => p.JobContracts)
                  .HasForeignKey(d => d.Company)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("JobContract_ibfk_2");

        entity.HasOne(d => d.PersonNavigation)
                  .WithMany(p => p.JobContracts)
                  .HasForeignKey(d => d.Person)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("JobContract_ibfk_1");
      });

      modelBuilder.Entity<JobContractAudit>(entity =>
      {
        entity.ToTable("JobContractAudit");

        entity.HasIndex(e => new { e.Person, e.Compnay }, "person");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.ChangedDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("changedDate");

        entity.Property(e => e.Compnay).HasColumnName("compnay");

        entity.Property(e => e.CurrentCompany).HasColumnName("currentCompany");

        entity.Property(e => e.CurrentPerson).HasColumnName("currentPerson");

        entity.Property(e => e.CurrentPosition)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("currentPosition");

        entity.Property(e => e.CurrentSalaryPerHour).HasColumnName("currentSalaryPerHour");

        entity.Property(e => e.CurrentStartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("currentStartDate");

        entity.Property(e => e.Person).HasColumnName("person");

        entity.Property(e => e.PreviousCompany).HasColumnName("previousCompany");

        entity.Property(e => e.PreviousPerson).HasColumnName("previousPerson");

        entity.Property(e => e.PreviousPosition)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("previousPosition");

        entity.Property(e => e.PreviousSalaryPerHour).HasColumnName("previousSalaryPerHour");

        entity.Property(e => e.PreviousStartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("previousStartDate");

        entity.HasOne(d => d.JobContract)
                  .WithMany(p => p.JobContractAudits)
                  .HasForeignKey(d => new { d.Person, d.Compnay })
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("JobContractAudit_ibfk_1");
      });

      modelBuilder.Entity<Person>(entity =>
      {
        entity.ToTable("Person");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Mail)
                  .HasMaxLength(255)
                  .HasColumnName("mail");

        entity.Property(e => e.Name)
                  .HasMaxLength(255)
                  .HasColumnName("name");

        entity.Property(e => e.Pass)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("pass");

        entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("username");
      });

      modelBuilder.Entity<PersonAudit>(entity =>
      {
        entity.ToTable("PersonAudit");

        entity.HasIndex(e => e.Person, "person");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.ChangedDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("changedDate");

        entity.Property(e => e.ChangedPass).HasColumnName("changedPass");

        entity.Property(e => e.CurrentMail)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("currentMail");

        entity.Property(e => e.CurrentName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("currentName");

        entity.Property(e => e.CurrentUsername)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("currentUsername");

        entity.Property(e => e.Person).HasColumnName("person");

        entity.Property(e => e.PreviousMail)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("previousMail");

        entity.Property(e => e.PreviousName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("previousName");

        entity.Property(e => e.PreviousUsername)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("previousUsername");

        entity.HasOne(d => d.PersonNavigation)
                  .WithMany(p => p.PersonAudits)
                  .HasForeignKey(d => d.Person)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("PersonAudit_ibfk_1");
      });

      modelBuilder.Entity<Schedule>(entity =>
      {
        entity.ToTable("Schedule");

        entity.HasIndex(e => new { e.Person, e.Company }, "person");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Company).HasColumnName("company");

        entity.Property(e => e.FinishDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("finishDate");

        entity.Property(e => e.Person).HasColumnName("person");

        entity.Property(e => e.StartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("startDate");

        entity.HasOne(d => d.JobContract)
                  .WithMany(p => p.Schedules)
                  .HasForeignKey(d => new { d.Person, d.Company })
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("Schedule_ibfk_1");
      });

      modelBuilder.Entity<ScheduleAudit>(entity =>
      {
        entity.HasKey(e => new { e.Id, e.CurrentFinishDate })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("ScheduleAudit");

        entity.HasIndex(e => e.Schedule, "schedule");

        entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .HasColumnName("id");

        entity.Property(e => e.CurrentFinishDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("currentFinishDate");

        entity.Property(e => e.ChangedDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("changedDate");

        entity.Property(e => e.CurrentCompany).HasColumnName("currentCompany");

        entity.Property(e => e.CurrentPerson).HasColumnName("currentPerson");

        entity.Property(e => e.CurrentStartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("currentStartDate");

        entity.Property(e => e.PreviousCompany).HasColumnName("previousCompany");

        entity.Property(e => e.PreviousFinishDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("previousFinishDate");

        entity.Property(e => e.PreviousPerson).HasColumnName("previousPerson");

        entity.Property(e => e.PreviousStartDate)
                  .HasColumnType("timestamp")
                  .HasColumnName("previousStartDate");

        entity.Property(e => e.Schedule).HasColumnName("schedule");

        entity.HasOne(d => d.ScheduleNavigation)
                  .WithMany(p => p.ScheduleAudits)
                  .HasForeignKey(d => d.Schedule)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("ScheduleAudit_ibfk_1");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
