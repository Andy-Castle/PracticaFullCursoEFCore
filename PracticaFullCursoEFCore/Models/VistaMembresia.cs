using System.ComponentModel.DataAnnotations;

namespace PracticaFullCursoEFCore.Models
{
    public class VistaMembresia
    {
        public int ID_Membresia { get; set; }

        public string TipoMembresia { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CostoMensual { get; set; }

    }
}
