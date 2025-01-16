using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.ViewModels
{
    public class PedidoClienteVM
    {
        public Pedidos Pedidos { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }
    }
}
