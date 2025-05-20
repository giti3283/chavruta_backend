using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה ב\\תלמידות\\תלמידות\\א לאה וגיטי\\proj\\פרויקט C#\\ChavrutaDataBase.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA678222CEE");

            entity.Property(e => e.Book).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Mode)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PersonId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Subject).UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Person).WithMany(p => p.Offers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Offers_ToPerson");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071DED013A");

            entity.ToTable("Person");

            entity.Property(e => e.Id)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.CellularTelephone)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Denomination)
                .HasMaxLength(20)
                .HasDefaultValueSql("('generic')")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("('single')")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Telephone)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA635E8ADA5");

            entity.Property(e => e.Book).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Mode).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.PersonId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Subject).UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.ChavrutaCodeNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ChavrutaCode)
                .HasConstraintName("FK_Requests_To Offers");

            entity.HasOne(d => d.Person).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Requests_To Person");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__tmp_ms_x__A25C5AA62381EA6F");

            entity.ToTable("Schedule");

            entity.Property(e => e.Available).HasDefaultValueSql("((0))");
            entity.Property(e => e.DayInWeek)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FromTime).HasPrecision(4);
            entity.Property(e => e.PersonId)
                .HasMaxLength(9)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.ToTime).HasPrecision(4);

            entity.HasOne(d => d.Person).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_ToPerson");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
