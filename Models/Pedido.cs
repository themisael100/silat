using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silat.Models;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public int UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public string Estado { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public int DireccionIdSeleccionada { get; set; }
    [ForeignKey("DireccionIdSeleccionada")]
    public Direccion Direccion { get; set; } = null!;
    public decimal Total { get; set; }
    public ICollection<Detalle_Pedido> DetallesPedido { get; set; } = null!;
}
