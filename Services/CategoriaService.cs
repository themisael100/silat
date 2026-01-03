using System;
using Microsoft.EntityFrameworkCore;
using silat.Data;
using silat.Models;

namespace silat.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ApplicationDbContext _context;
    public CategoriaService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Categoria>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }
}
