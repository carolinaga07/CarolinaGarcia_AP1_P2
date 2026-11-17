using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Models;

namespace SegundoParcialCarolina.Context;

public class Contexto: DbContext
{
     public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public virtual DbSet<Productos> Productos { get; set; }
    public virtual DbSet<Ventas> Ventas { get; set; }
    public virtual DbSet<VentasDetalle> VentasDetalles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Productos>().HasData(
            new Productos { ProductoId = 1, Nombre = "Starbucks Mocha", Precio = 150, Stock = 10 },
            new Productos { ProductoId = 2, Nombre = "Starbucks Vainilla", Precio = 150, Stock = 10 },
            new Productos { ProductoId = 3, Nombre = "Starbucks Caramelo", Precio = 160, Stock = 10 },
            new Productos { ProductoId = 4, Nombre = "Starbucks Americano", Precio = 120, Stock = 10 },
            new Productos { ProductoId = 5, Nombre = "Starbucks Latte", Precio = 140, Stock = 10 }
        );
    }
    
}
