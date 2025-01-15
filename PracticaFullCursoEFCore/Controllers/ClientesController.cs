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
        public IActionResult Crear(ClienteMembresiaVM clienteMembresia)
        {

            if (ModelState.IsValid)
            {
                _context.Clientes.Add(clienteMembresia.Clientes);
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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            ClienteMembresiaVM clienteMembresias = new ClienteMembresiaVM();

            clienteMembresias.ListaMembresias = _context.Membresias.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = m.TipoMembresia,
                Value = m.ID_Membresia.ToString()
            });


            clienteMembresias.Clientes = _context.Clientes.FirstOrDefault(c => c.ID_Cliente == id);

            if (clienteMembresias == null)
            {
                return NotFound();
            }

            return View(clienteMembresias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Editar(ClienteMembresiaVM clienteMembresia)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(clienteMembresia.Clientes);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(clienteMembresia);

        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
