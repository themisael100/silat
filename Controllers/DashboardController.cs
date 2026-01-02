using Microsoft.AspNetCore.Mvc;
using silat.Data;

namespace silat.Controllers
{
    public class DashboardController : BaseController
    {
     public DashboardController(ApplicationDbContext context):base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
