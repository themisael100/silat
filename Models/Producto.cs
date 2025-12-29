using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silat.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(50)]
    public string Codigo { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(255)]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(255)]
    public string Modelo { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(1000)]
    public string Descripcion { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DataType(DataType.Currency)]
    public decimal Precio { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(255)]
    [DataType(DataType.ImageUrl)]
    public string Imagen { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public int CategoriaId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(150)]
    public string Marca { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    public bool Activo { get; set; }
    public ICollection<Detalle_Pedido> DetallesPedido { get; set; } = null!;
}
