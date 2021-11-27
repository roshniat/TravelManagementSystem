using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelManagementApp.Models
{
    public partial class TravelManagementDBContext : DbContext
    {
        public TravelManagementDBContext()
        {
        }

        public TravelManagementDBContext(DbContextOptions<TravelManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<ProjectTable> ProjectTable { get; set; }
        public virtual DbSet<RequestTable> RequestTable { get; set; }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ROSHNIAT\\SQLEXPRESS; Initial Catalog=TravelManagementDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRegistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99CE69CF24");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("L_Id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.EmployeeRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__EmployeeRe__L_Id__38996AB5");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__4208A4A613DCA01B");

                entity.Property(e => e.LId).HasColumnName("L_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectTable>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__ProjectT__761ABEF02D300E30");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequestTable>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__RequestT__33A8517ABBE846D0");

                entity.Property(e => e.CauseTravel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate)
                    .HasColumnName("From_date")
                    .HasColumnType("date");

                entity.Property(e => e.Mode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoDays).HasColumnName("No_Days");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("To_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__RequestTa__EmpId__3E52440B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.RequestTable)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__RequestTa__Proje__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
