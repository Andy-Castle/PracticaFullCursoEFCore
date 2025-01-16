using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaFullCursoEFCore.Data;
using PracticaFullCursoEFCore.Models;
using PracticaFullCursoEFCore.ViewModels;

namespace PracticaFullCursoEFCore.Controllers
{
    public class PedidosController : Controller
    {
        public readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Pedidos> listaPedidos = _context.Pedidos.Include(clientes => clientes.Clientes).ToList();

            return View(listaPedidos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            PedidoClienteVM pedidoClientes = new PedidoClienteVM();

            pedidoClientes.ListaClientes = _context.Clientes.Select(l => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = l.Nombre,
                Value = l.ID_Cliente.ToString()
            });

            return View(pedidoClientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(PedidoClienteVM pedidoClienteVM)
        {
            if (ModelState.IsValid)
            {
                _context.Pedidos.Add(pedidoClienteVM.Pedidos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            pedidoClienteVM.ListaClientes = _context.Clientes.Select(l => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = l.Nombre,
                Value = l.ID_Cliente.ToString()
            });

            return View(pedidoClienteVM);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }

            PedidoClienteVM pedidoClientes = new PedidoClienteVM();

            pedidoClientes.ListaClientes = _context.Clientes.Select(l => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = l.Nombre,
                Value = l.ID_Cliente.ToString()
            });

            pedidoClientes.Pedidos = _context.Pedidos.FirstOrDefault(pedido => pedido.ID_Pedido == id);

            if (pedidoClientes == null)
            {
                return NotFound();
            }

            return View(pedidoClientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(PedidoClienteVM pedidoClienteVM)
        {
            if (pedidoClienteVM.Pedidos.ID_Pedido == 0)
            {
                return View(pedidoClienteVM.Pedidos);
            }
            else
            {
                _context.Pedidos.Update(pedidoClienteVM.Pedidos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.ID_Pedido == id);
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AdministrarProductosPedidos(int id)
        {
            PedidoProductoVM pedidoProductos = new PedidoProductoVM
            {
                ListaPedidosProductos = _context.PedidoProductos.Include(producto => producto.Productos).Include(pedido => pedido.Pedidos)
                .Where(p => p.ID_Pedido == id),

                PedidoProducto = new PedidoProductos()
                {
                    ID_Pedido = id,
                },

                Pedido = _context.Pedidos.FirstOrDefault(p => p.ID_Pedido == id)
            };

            List<int> listaTemporalProductosPedido = pedidoProductos.ListaPedidosProductos.Select(e => e.ID_Producto).ToList();

            //var listaTemporal = _context.Productos.Where(e => !listaTemporalProductosPedido.Contains(e.ID_Producto)).ToList();
            var listaTemporal = _context.Productos.ToList();


            pedidoProductos.ListaProductos = listaTemporal.Select(i => new SelectListItem
            {
                Text = i.Nombre,
                Value = i.ID_Producto.ToString()
            });

            return View(pedidoProductos);
        }

        [HttpPost]
        public IActionResult AdministrarProductos (PedidoProductoVM pedidoProductos)
        {
            if (pedidoProductos.PedidoProducto.ID_Pedido != 0 && pedidoProductos.PedidoProducto.ID_Producto != 0)
            {
                _context.PedidoProductos.Add(pedidoProductos.PedidoProducto);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(AdministrarProductosPedidos), new {@id = pedidoProductos.PedidoProducto.ID_Pedido});
        }

        [HttpPost]
        public IActionResult EliminarProductos(int idProducto, int idPedido)
        {
            var pedidoProducto = _context.PedidoProductos.FirstOrDefault(
                    p => p.ID_Producto == idProducto && p.ID_Pedido == idPedido);

            if (pedidoProducto != null)
            {
                _context.PedidoProductos.Remove(pedidoProducto);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(AdministrarProductosPedidos), new { @id = idPedido });

        }
    }
}
