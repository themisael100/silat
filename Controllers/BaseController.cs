using Microsoft.AspNetCore.Mvc;

namespace silat.Controllers
{
    public class BaseController : Controller
    {
      public readonly ApplicationDbContext _context;

      public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        
    }
}
