using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.ViewModels
{
    public class PedidoProductoVM
    {
        public PedidoProductos PedidoProducto { get; set; }

        public Pedidos Pedido { get; set; }

        public IEnumerable<PedidoProductos> ListaPedidosProductos { get; set; }

        public IEnumerable<SelectListItem> ListaProductos { get; set; }
    }
}
