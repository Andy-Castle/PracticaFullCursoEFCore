using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.ViewModels
{
    public class ClientePedidoVM
    {
        public Clientes Clientes { get; set; }

        public IEnumerable<SelectListItem> ListaPedidos { get; set; }
    }
}
