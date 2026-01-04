using System;
using silat.Models;
using silat.Models.ViewModels;

namespace silat.Services;

public interface IProductoService
{
    Producto GetProducto(int id);
    Task<List<Producto>> GetProductoDestacado();
    Task<ProductosPaginadosViewModel> GetProductosPaginados(int? categoriaId, string? busqueda, int pagina, int prodyctosPorPaginas);
}