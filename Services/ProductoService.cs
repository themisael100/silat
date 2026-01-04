using System;
using Microsoft.EntityFrameworkCore;
using silat.Data;
using silat.Models;
using silat.Models.ViewModels;

namespace silat.Services;

public class ProductoService : IProductoService
{
    private readonly ApplicationDbContext _context;
    public ProductoService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Producto GetProducto(int id)
    {
        var producto = _context.Productos
        .Include(p => p.Categoria)
        .FirstOrDefault(p => p.ProductoId == id);

        if (producto != null)
            return producto;

        return new Producto();
    }

    public async Task<List<Producto>> GetProductoDestacado()
    {
        IQueryable<Producto> productosQuery = _context.Productos;
        productosQuery = productosQuery.Where(p => p.Activo);

        List<Producto> ProductosDestacados = await productosQuery
        .Take(9)
        .ToListAsync();
        return ProductosDestacados;

    }

    public async Task<ProductosPaginadosViewModel> GetProductosPaginados(int? categoriaId, string? busqueda, int pagina, int productosPorPagina)
    {
        IQueryable<Producto> query = _context.Productos;
        query = query.Where(p => p.Activo);

        if (categoriaId.HasValue)
            query = query.Where(p => p.CategoriaId == categoriaId);

        if (!String.IsNullOrEmpty(busqueda))
            query = query.Where(p => p.Nombre.Contains(busqueda) || p.Descripcion.Contains(busqueda));

        int TotalProductos = await query.CountAsync();

        int totalPaginas = (int)Math.Ceiling((double)TotalProductos) / productosPorPagina;

        if (pagina < 1)
            pagina = 1;
        else if (pagina > totalPaginas)
            pagina = totalPaginas;

        List<Producto> productos = new();
        if (TotalProductos > 0)
        {
            productos = await query.OrderBy(p => p.Nombre)
            .Skip((pagina - 1) * productosPorPagina)
            .Take(productosPorPagina)
            .ToListAsync();
        }

        bool mostrarMensajeSinResultados = TotalProductos == 0;
        var model = new ProductosPaginadosViewModel
        {
            Productos = productos,
            PaginaActual = pagina,
            TotalPaginas = totalPaginas,
            CategoriaIdSeleccionada = categoriaId,
            Busqueda = busqueda,
            MostrarMensajeSinResultado = mostrarMensajeSinResultados
        };
        return model;
    }
}
