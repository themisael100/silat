using Microsoft.AspNetCore.Mvc;
using silat.Data;
using silat.Models;
using silat.Services;

namespace silat.Controllers;

public class HomeController : BaseController
{
    private readonly IProductoService _productoService;
    private readonly ICategoriaService _categiriaService;
    public HomeController(ApplicationDbContext context, IProductoService productoService, ICategoriaService categoriaService) : base(context)
    {
        _productoService = productoService;
        _categiriaService = categoriaService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Categorias = await _categiriaService.GetCategorias();

        try
        {
            List<Producto> productosDestacadaos = await _productoService.GetProductoDestacado();
            return View(productosDestacadaos);
        }
        catch (Exception e)
        {

            return HandleError(e);
        }
    }

    public IActionResult DetalleProductos(int id)
    {
        var producto = _productoService.GetProducto(id);
        if (producto == null)
            return NotFound();

        return View(producto);
    }

    public async Task<IActionResult> Productos(int? categoriaId, string? busqueda, int pagina = 1)
    {
        try
        {
            int productosPorPaginas = 9;
            var model = await _productoService.GetProductosPaginados(categoriaId, busqueda, pagina, productosPorPaginas);

            ViewBag.Categoria = await _categiriaService.GetCategorias();

            if (Request.Headers["X-Request-With"] == "XMLHttpRequest")
            {
                return PartialView("_ProductosPartial", model);
            }
            return View(model);
        }
        catch (Exception e)
        {

            return HandleError(e);
        }
    }

    public async Task<IActionResult> AgregarProducto(int id, int cantidad, int? categoriaId, string? busqueda, int pagina = 1)
    {
        var carritoViewModel = await AgregarProductoAlCarrito(id, cantidad);
        if (carritoViewModel != null)
        {
            return RedirectToAction(
                "Productos",
                 new
                 {
                     id,
                     categoriaId,
                     busqueda,
                     pagina
                 }
             );
        }
        else
            return NotFound();
    }

    public async Task<IActionResult> AgregarProductoIndex(int id, int cantidad)
    {
        var carritoViewModel = await AgregarProductoAlCarrito(id, cantidad);
        if (carritoViewModel != null)
        {
            return RedirectToAction("Index");
        }
        else
            return NotFound();
    }

    public async Task<IActionResult> AgregarProductoDetalle(int id, int cantidad)
    {
        var carritoViewModel = await AgregarProductoAlCarrito(id, cantidad);
        if (carritoViewModel != null)
        {
            return RedirectToAction("DetalleProducto", new { id });
        }
        else
            return NotFound();
    }
    public IActionResult Privacy()
    {
        return View();
    }
}
