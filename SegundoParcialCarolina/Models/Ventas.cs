using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegundoParcialCarolina.Models;

public class Ventas
{
    [Key]
    public int VentaId { get; set; }
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Observacion { get; set; } = string.Empty;
    public double Total { get; set; }
   
    [InverseProperty("Venta")]
    public List<VentasDetalle> Detalles { get; set; } = new List<VentasDetalle>();
}
