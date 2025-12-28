using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silat.Models;

public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "EL nombre es obligatorio")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;
    public string NombreUsuario { get; set; } = null!;
    public string Contrasenia { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Ciudad { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string CodigoPostal { get; set; } = null!;


    public int RolId { get; set; }

    [ForeignKey("RolId")]
    public Rol Rol { get; set; } = null!;


    public ICollection<Pedido> Pedidos { get; set; }
    public ICollection<Direccion> Direcciones { get; set; } = null!;
}
