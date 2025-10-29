using System;
using Microsoft.EntityFrameworkCore;
using clasesGYM_;
public class AplicationDbContext : DbContext
{

    public DbSet<Pagos> Pagos { get; set; }
    public DbSet<Suscripcion> Suscripciones { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Clase> Clases { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
    "Server=localHost;Database=SistemaGym_;Trusted_Connection=True;TrustServerCertificate=True;"
);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de tablas
        modelBuilder.Entity<Pagos>().ToTable("Pagos");
        modelBuilder.Entity<Suscripcion>().ToTable("Suscripciones");
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        modelBuilder.Entity<Clase>().ToTable("Clases");

        // CONFIGURACIÓN DE LA RELACIÓN ENTRE CLIENTE Y SUSCRIPCIÓN
        // Un Cliente tiene UNA Suscripción (referenciada por SuscripcionId)
        // Una Suscripción puede pertenecer a MUCHOS Clientes
        modelBuilder.Entity<Cliente>()
            .HasOne<Suscripcion>()                      // Un Cliente tiene UNA Suscripción
            .WithMany()                                 // Una Suscripción puede tener MUCHOS Clientes
            .HasForeignKey(c => c.SuscripcionId)       // La clave foránea es SuscripcionId
            .IsRequired(true);                          // La suscripción es OBLIGATORIA (no puede ser null)
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Pago)                     // Cliente tiene un Pago
            .WithOne(p => p.ClientePago)                  // Pago tiene un Cliente
            .HasForeignKey<Pagos>(p => p.ClienteId)     // La clave foránea está en Pago
            .IsRequired(true);                       // El pago es obligatorio

    }
}
