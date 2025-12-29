using System.ComponentModel.DataAnnotations;

namespace silat.Models;

public class Rol
{
    [Key]
    public int RolId { get; set; }
    [Required(ErrorMessage = "El campo es obligatorio")]
    [StringLength(50)]
    public string NombreRol { get; set; } = null!;
}
