using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcialCarolina.Models;

public class Productos
{
    [Key]
    public int ProductoId{ get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    public string Nombre { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser negativo.")]
    public double Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }

    [InverseProperty("Producto")]
    public List<VentasDetalle> Detalles { get; set; } = new List<VentasDetalle>();
}
