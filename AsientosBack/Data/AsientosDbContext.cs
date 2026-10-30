using System;
using System.Collections.Generic;
using AsientosBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AsientosBack.Data;

public partial class AsientosDbContext : DbContext
{
    public AsientosDbContext()
    {
    }

    public AsientosDbContext(DbContextOptions<AsientosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.IdAsiento).HasName("PK__Asiento__F56787218D50277D");

            entity.ToTable("Asiento");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaAsiento).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_departamento");

            entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.Asientos)
                .HasForeignKey(d => d.IdMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Movimiento");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D85FBD88C");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__881A6AE055A77D90");

            entity.ToTable("Movimiento");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Ncuenta)
                .HasMaxLength(100)
                .HasColumnName("NCuenta");
            entity.Property(e => e.Valor).HasColumnType("decimal(9, 6)");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipo");
        });

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__TipoMovi__9E3A29A5B7D06DEF");

            entity.ToTable("TipoMovimiento");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
