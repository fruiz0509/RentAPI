using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RentAPI.Models;

public partial class RentDbContext : DbContext
{
    public RentDbContext()
    {
    }

    public RentDbContext(DbContextOptions<RentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3213E83FDD810DDC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.Paid)
                .HasColumnType("money")
                .HasColumnName("paid");
            entity.Property(e => e.RentId).HasColumnName("rentId");
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rents__3213E83F2A395F5F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Comments)
                .HasMaxLength(3000)
                .HasColumnName("comments");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.RentEndDate)
                .HasColumnType("date")
                .HasColumnName("rentEndDate");
            entity.Property(e => e.RentEndHour).HasColumnName("rentEndHour");
            entity.Property(e => e.RentStartDate)
                .HasColumnType("date")
                .HasColumnName("rentStartDate");
            entity.Property(e => e.RentStartHour).HasColumnName("rentStartHour");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VisitId).HasColumnName("visitId");

            entity.HasOne(d => d.User).WithMany(p => p.Rents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_rentuser");

            entity.HasOne(d => d.Visit).WithMany(p => p.Rents)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("fk_rentvisit");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83F2D6DCABA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FD835F98F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.Pass)
                .HasMaxLength(20)
                .HasColumnName("pass");
            entity.Property(e => e.RolId).HasColumnName("rolId");

            entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("fk_userrol");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Visits__3213E83F3A308395");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VisitDate)
                .HasColumnType("date")
                .HasColumnName("visitDate");
            entity.Property(e => e.VisitHour).HasColumnName("visitHour");

            entity.HasOne(d => d.User).WithMany(p => p.Visits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_appointmentuser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
