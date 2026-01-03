using silat.Models;

namespace silat.Services;

public interface ICategoriaService
{
    Task<List<Categoria>> GetCategorias();
}
