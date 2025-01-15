using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaFullCursoEFCore.Models;

namespace PracticaFullCursoEFCore.ViewModels
{
    public class ClienteMembresiaVM
    {
        public  Clientes Clientes { get; set; }

        public IEnumerable<SelectListItem> ListaMembresias { get; set; }

     
    }
}
