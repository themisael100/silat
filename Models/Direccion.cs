using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silat.Models;

public class Direccion
{
    [Key]
    public int DireccionId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(255)]
    public string Adress { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(40)]
    public string Ciudad { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;
    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(10)]
    public string CodigoPostal { get; set; } = null!;
    [Required (ErrorMessage ="El campo es obligatorio.")]
    public int UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;
}
