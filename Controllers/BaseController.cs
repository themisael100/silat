using Microsoft.AspNetCore.Mvc;
using silat.Data;

namespace silat.Controllers
{
    public class BaseController : Controller
    {
        public readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public override ViewResult View(string? viewName)
        {
            return base.View();
        }
    }
}
