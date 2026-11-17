using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Models;

namespace SegundoParcialCarolina.Context;

public class Contexto: DbContext
{
     public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public virtual DbSet<Productos> Productos { get; set; }
    public virtual DbSet<Ventas> Ventas { get; set; }
    public virtual DbSet<VentasDetalle> VentasDetalles { get; set; }
    
}
