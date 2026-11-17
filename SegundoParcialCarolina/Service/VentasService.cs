using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using SegundoParcialCarolina.Context;
using SegundoParcialCarolina.Models;
using System.Linq.Expressions;

namespace SegundoParcialCarolina.Service;

public class VentasService(IDbContextFactory<Contexto> contextFactory) 
    : Aplicada1.Core.IServiceResult<Ventas, int>
{
    
      public async Task<Result> Guardar(Ventas venta)
      {
        if(venta.Detalles == null || !venta.Detalles.Any())
        {
            return Result.Failure(new Error("Ventas","Debe agregar al menos un producto"));
        }
        venta.Total = venta.Detalles.Sum(v => v.Cantidad * v.Precio);
        var guardado = await Existe(venta.VentaId) ? await Modificar(venta) : await Insertar(venta);
        return guardado ? Result.Success(true) : Result.Failure(new Error("Ventas","No se pudo guardar la venta, revise el stock"));
      }
      private async Task<bool> Existe (int ventaId)
      {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas.AnyAsync(v => v.VentaId == ventaId);
      }

      private async Task<bool> Insertar(Ventas venta)
      {
        await using var contexto = await contextFactory.CreateDbContextAsync();
       
        if(!await AfectarStock(contexto, venta.Detalles, -1))
        {
            return false;
        }

        contexto.Ventas.Add(venta);
        return await contexto.SaveChangesAsync() > 0;
      }

    private async Task<bool> Modificar(Ventas venta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var original = await contexto.Ventas
            .Include(v => v.Detalles)
            .FirstOrDefaultAsync(v => v.VentaId == venta.VentaId);

        if(original == null)
        {
            return false;
        }

        if(!await AfectarStock(contexto, original.Detalles, 1))
        {
            return false;
        }

        if(!await AfectarStock(contexto, venta.Detalles, -1))
        {
            return false;
        }
        contexto.VentasDetalles.RemoveRange(original.Detalles);
        contexto.VentasDetalles.AddRange(
            (venta.Detalles.Select(d => new VentasDetalle
            {
                VentaId = original.VentaId,
                ProductoId = d.ProductoId,
                Cantidad = d.Cantidad,
                Precio = d.Precio
            })));
        original.Fecha = venta.Fecha;
        original.Observacion = venta.Observacion;
        original.Total = venta.Total;

        return await contexto.SaveChangesAsync() > 0;
    }


    public async Task<Result<Ventas?>> Buscar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Include(v => v.Detalles)
            .ThenInclude(d => d.Producto)
            .AsNoTracking()
            .FirstOrDefaultAsync(v => v.VentaId == ventaId);
    }
    public async Task<Result<List<Ventas>>> GetList(Expression<Func<Ventas, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Ventas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Result> Eliminar(int ventaId)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();

        var venta = await contexto.Ventas
            .Include(v => v.Detalles)
            .FirstOrDefaultAsync(v => v.VentaId == ventaId);

        if(venta == null)
        {
            return Result.Failure(new Error("Ventas", "Venta no encontrada."));
        }

        if(!await AfectarStock(contexto, venta.Detalles, 1))
        {
            return Result.Failure(new Error("Ventas", "Producto no encontrado"));
        }

        contexto.VentasDetalles.RemoveRange(venta.Detalles);
        contexto.Ventas.Remove(venta);

        return await contexto.SaveChangesAsync() > 0 ? Result.Success(true) : Result.Failure(new Error("Ventas", "No se pudo eliminar"));
    }

    private async Task<bool> AfectarStock(Contexto contexto, List<VentasDetalle> detalles, int signo)
    {
        foreach (var detalle in detalles)
        {
            if (detalle.Cantidad <= 0)
            {
                return false;
            }

            var producto = await contexto.Productos
                .FindAsync(detalle.ProductoId);

            if (producto == null)
            {
                return false;
            }

            producto.Stock += detalle.Cantidad * signo;

            if (producto.Stock < 0)
            {
                return false;
            }
        }

        return true;
    }
    
    public async Task<List<Productos>> ListarProductos()
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Productos.AsNoTracking().ToListAsync();
    }




}
