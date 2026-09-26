using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenSinhBinhMinh_2410900053_exam.Models;

public partial class NguyenSinhBinhMinhStudentContext : DbContext
{
    public NguyenSinhBinhMinhStudentContext()
    {
    }

    public NguyenSinhBinhMinhStudentContext(DbContextOptions<NguyenSinhBinhMinhStudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NguyenSinhBinhMinhStudent> NguyenSinhBinhMinhStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NguyenSinhBinhMinhStudent;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NguyenSinhBinhMinhStudent>(entity =>
        {
            entity.ToTable("NguyenSinhBinhMinhStudent");

            entity.Property(e => e.NguyenSinhBinhMinhBirthday).HasColumnType("datetime");
            entity.Property(e => e.NguyenSinhBinhMinhEmail)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.NguyenSinhBinhMinhGender)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NguyenSinhBinhMinhName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NguyenSinhBinhMinhPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
