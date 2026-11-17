using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcialCarolina.Models;

public class Productos
{
    [Key]
    public int ProductoId{ get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    public string Nombre { get; set; } = string.Empty;

    public double Precio { get; set; }
    public int Stock { get; set; }

    [InverseProperty("Producto")]
    public List<VentasDetalle> Detalles { get; set; } = new List<VentasDetalle>();
}
