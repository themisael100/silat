using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using silat.Data;
using silat.Models;

namespace silat.Controllers;

public class HomeController : BaseController
{
    public HomeController(ApplicationDbContext context) : base(context)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
