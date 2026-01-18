using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using silat.Data;

namespace silat.Controllers
{
    [Authorize(Policy = "RequireAdminOrStaff")]
    public class DashboardController : BaseController
    {
        public DashboardController(ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
