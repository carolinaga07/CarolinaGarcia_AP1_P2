using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcialCarolina.Models;

public class VentasDetalle
{
    [Key]
    public int DetalleId { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser negativo.")]
    public double Precio { get; set; }

    [ForeignKey("VentaId")]
    [InverseProperty("Detalles")]
    public Ventas ? Venta { get; set; }

    [ForeignKey("ProductoId")]
    [InverseProperty("Detalles")]
    public Productos? Producto { get; set; }
}
