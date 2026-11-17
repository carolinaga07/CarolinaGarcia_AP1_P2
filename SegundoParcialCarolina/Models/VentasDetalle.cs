using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcialCarolina.Models;

public class VentasDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }

    public int Cantidad { get; set; }
    public double Precio { get; set; }

    [ForeignKey("VentaId")]
    [InverseProperty("Detalles")]
    public Ventas ? Venta { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("Detalles")]
    public Productos? Producto { get; set; }
}
