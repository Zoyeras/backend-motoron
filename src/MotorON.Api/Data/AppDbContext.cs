using Microsoft.EntityFrameworkCore;
using MotorON.Api.Models;

namespace MotorON.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Mantenimiento> Mantenimientos => Set<Mantenimiento>();
    public DbSet<GastoCombustible> GastosCombustible => Set<GastoCombustible>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("vehicles");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Brand).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Model).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => new { x.Brand, x.Model });
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.ToTable("mantenimientos");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Tipo).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Costo).HasColumnType("numeric(12,2)");
            entity.Property(x => x.Descripcion).HasMaxLength(500);
            entity.HasIndex(x => x.Fecha);
            entity.HasIndex(x => x.Kilometraje);
        });

        modelBuilder.Entity<GastoCombustible>(entity =>
        {
            entity.ToTable("gastos_combustible");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Costo).HasColumnType("numeric(12,2)");
            entity.Property(x => x.Litros).HasColumnType("numeric(12,3)");
            entity.HasIndex(x => x.Fecha);
            entity.HasIndex(x => x.Kilometraje);
        });
    }
}
