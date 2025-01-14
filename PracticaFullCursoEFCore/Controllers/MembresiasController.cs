using Microsoft.AspNetCore.Mvc;
using PracticaFullCursoEFCore.Data;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.Controllers
{
    public class MembresiasController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MembresiasController(ApplicationDbContext context)
        {
               _context = context;
        }

        public IActionResult Index()
        {
            List<Membresias> lsitaMembresias = _context.Membresias.ToList();

            return View(lsitaMembresias);
        }
    }
}
