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
            List<Membresias> listaMembresias = _context.Membresias.ToList();

            return View(listaMembresias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Membresias membresias)
        {
            if (ModelState.IsValid)
            {
                _context.Membresias.Add(membresias);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));   
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return View();
            }

            var membresia = _context.Membresias.FirstOrDefault(m => m.ID_Membresia == id);
            return View(membresia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Membresias membresia)
        {
            if (ModelState.IsValid)
            {
                _context.Membresias.Update(membresia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(membresia);
        }

        [HttpGet]
        public IActionResult Borrar (int? id)
        {
            var membresia = _context.Membresias.FirstOrDefault(m => m.ID_Membresia == id);
            //var membresia  = _context.Membresias.Find(id);
            if (membresia != null)
            {
                _context.Membresias.Remove(membresia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
              
            } 

            return View();
        }
    }
}
