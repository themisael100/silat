using System;
using System.ComponentModel.DataAnnotations;

namespace silat.Models;

public class Rol
{
    [Key]
    public int IdRol { get; set; }

    [Required(ErrorMessage = "El campo nombre es obligatorio")]
    [StringLength(50)]
    public string RolName { get; set; } = null!;

}
