using System.Data.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silat.Data;
using silat.Models;

namespace silat.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ApplicationDbContext context) : base(context)
        {
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == usuario.NombreUsuario))
                    {
                        ModelState.AddModelError(nameof(usuario.NombreUsuario), "El nombre de usaurio ya esta en uso.");
                        return View(usuario);
                    }
                    var clienteRol = await _context.Roles.FirstOrDefaultAsync(r => r.NombreRol == "Cliente");
                    if (clienteRol != null)
                    {
                        usuario.RolId = clienteRol.RolId;
                    }
                    usuario.Direcciones = new List<Direccion>
                    {
                        new Direccion
                        {
                            Adress = usuario.Direccion,
                            Ciudad = usuario.Ciudad,
                            CodigoPostal = usuario.CodigoPostal,
                            Estado = usuario.Estado
                        }
                    };
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.NombreUsuario));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Cliente"));

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                return View(usuario);
            }
            catch (DbException dbException)
            {

                return HandleDbError(dbException);
            }
        }
    }
}
