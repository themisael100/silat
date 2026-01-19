using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silat.Data;

namespace silat.ViewComponents
{
    public class CategoriasMenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoriasMenuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return View(categorias);
        }
    }
}