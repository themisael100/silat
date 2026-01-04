using System.Data.Common;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using silat.Data;
using silat.Models;
using silat.Models.ViewModels;

namespace silat.Controllers
{
    public class BaseController : Controller
    {
        public readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public override ViewResult View(string? viewName, object? model)
        {
            ViewBag.NumeroProductos = GetCarritoCount();
            return base.View(viewName, model);
        }

        protected int GetCarritoCount()
        {
            var count = 0;

            string? carritoJson = Request.Cookies["carrito"];
            if (!string.IsNullOrEmpty(carritoJson))
            {
                var carrito = JsonConvert.DeserializeObject<List<ProductoIdAndCantidad>>(carritoJson);
                {
                    if (carrito != null)
                    {
                        count = carrito.Count;
                    }
                }
            }
            return count;
        }
        protected IActionResult HandleError(Exception e)
        {
            return View
            (
                "Error",
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }

        protected IActionResult HandleDbError(DbException dbException)
        {
            var ViewModel = new DbErrorViewModel
            {
                ErrorMessage = "Error de base de datos",
                Details = dbException.Message
            };
            return View("DbError", ViewModel);
        }

        protected IActionResult HandleDbUpdateError(DbUpdateException dbUpdateException)
        {
            var ViewModel = new DbErrorViewModel
            {
                ErrorMessage = "Error de actualización de base de datos",
                Details = dbUpdateException.Message
            };
            return View("DbError", ViewModel);
        }

    }
}
