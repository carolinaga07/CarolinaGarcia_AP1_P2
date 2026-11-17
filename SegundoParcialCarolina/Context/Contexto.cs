using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Models;

namespace SegundoParcialCarolina.Context;

public class Contexto: DbContext
{
     public Contexto(DbContextOptions<Contexto> options) : base(options) { }

     public virtual DbSet<Productos> Model1s { get; set; }
    
}
