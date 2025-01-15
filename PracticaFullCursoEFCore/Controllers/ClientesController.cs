using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaFullCursoEFCore.Data;
using PracticaFullCursoEFCore.Models;
using PracticaFullCursoEFCore.ViewModels;

namespace PracticaFullCursoEFCore.Controllers
{
    public class ClientesController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Clientes> listaClientes = _context.Clientes.Include(m => m.Membresias).ToList();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ClienteMembresiaVM clienteMembresias = new ClienteMembresiaVM();

            clienteMembresias.ListaMembresias = _context.Membresias.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = m.TipoMembresia,
                Value = m.ID_Membresia.ToString()
            });

            return View(clienteMembresias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear (Clientes cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));   
            }

            ClienteMembresiaVM clienteMembresias = new ClienteMembresiaVM();

            clienteMembresias.ListaMembresias = _context.Membresias.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = m.TipoMembresia,
                Value = m.ID_Membresia.ToString()
            });

            return View(clienteMembresias);
        }
    }
}
