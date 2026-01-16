using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using silat.Data;
using silat.Models;
using silat.Models.ViewModels;

namespace silat.Controllers
{
    public class CarritoController : BaseController
    {
        public CarritoController(ApplicationDbContext context) : base(context)
        {
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var carritoViewModel = await GetCarritoViewModelAsync();

            foreach (var item in carritoViewModel.Items)
            {
                var producto = await _context.Productos.FindAsync(item.ProductoId);
                if (producto != null)
                {
                    item.Producto = producto;
                    if (!producto.Activo)
                        item.Cantidad = 0;
                    else
                        item.Cantidad = Math.Min(item.Cantidad, producto.Stock);

                    if (item.Cantidad == 0)
                        item.Cantidad = 1;

                }
                else
                    item.Cantidad = 0;
            }
            var usuarioId = User.Identity?.IsAuthenticated == true ? int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)) : 0;

            var direcciones = User.Identity?.IsAuthenticated == true ? _context.Direcciones.Where(d => d.UsuarioId == usuarioId).ToList() : new List<Direccion>();


            var procederConCompraViewModel = new ProcederConCompraViewModel
            {
                Carrito = carritoViewModel,
                Direcciones = direcciones
            };
            return View(procederConCompraViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCantidad(int id, int cantidad)
        {
            var carritoViewModel = await GetCarritoViewModelAsync();
            var carritoItem = carritoViewModel.Items.FirstOrDefault(i => i.ProductoId == id);

            if (carritoItem != null)
            {
                carritoItem.Cantidad = cantidad;
                var producto = await _context.Productos.FindAsync(id);
                if (producto != null && producto.Activo && producto.Stock > 0)
                    carritoItem.Cantidad = Math.Min(cantidad, producto.Stock);

                await UpdateCarritoViewModelAsync(carritoViewModel);

            }
            return RedirectToAction("Index", "Carrito");
        }
    }
}
