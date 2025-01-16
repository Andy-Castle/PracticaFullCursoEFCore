using Microsoft.AspNetCore.Mvc;
using PracticaFullCursoEFCore.Data;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Productos> listaProductos = _context.Productos.ToList();

            return View(listaProductos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Productos productos)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(productos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var producto = _context.Productos.FirstOrDefault(p => p.ID_Producto == id);
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Productos producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.ID_Producto == id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
