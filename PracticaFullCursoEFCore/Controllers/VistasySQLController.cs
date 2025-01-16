using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaFullCursoEFCore.Data;

namespace PracticaFullCursoEFCore.Controllers
{
    public class VistasySQLController : Controller
    {
        public readonly ApplicationDbContext _context;

        public VistasySQLController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            var membresias = _context.VistaMembresias.ToList();

            return View(membresias);
        }

        public IActionResult Filtrar()
        {
            var membresias = _context.VistaMembresias
                .FromSqlInterpolated($"SELECT * FROM ObtenerMembresias WHERE CostoMensual >= 1500")
                .ToList();

            return View("Index", membresias);
        }
    }
}
