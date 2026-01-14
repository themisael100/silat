using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silat.Data;

namespace silat.Controllers
{
    public class PerfilController : BaseController
    {
        public PerfilController(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var usuario = await _context.Usuarios
            .Include(u => u.Direcciones)
            .FirstOrDefaultAsync(u => u.UsuarioId == id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

    }
}
