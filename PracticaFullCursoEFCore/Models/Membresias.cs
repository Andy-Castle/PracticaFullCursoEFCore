using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFullCursoEFCore.Models
{
    public class Membresias
    {
        [Key]
        public int ID_Membresia { get; set; }


        [StringLength(50)]
        [Display(Name = "Tipos de Membresia")]
        [Required(ErrorMessage = "Agregue una membresia")]
        public string TipoMembresia { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Agregue una Fecha de inicio")]
        public DateTime FechaInicio { get; set; } = DateTime.Now;


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de fin")]
        [Required(ErrorMessage = "Agregue fecha de finalización")]
        public DateTime FechaFin {  get; set; }


        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Costo Mensual")]
        [Required(ErrorMessage = "Agregue el costo mensual")]
        public decimal CostoMensual { get; set; }

        //Esta es para la relación uno a Muchos Cliente - Membresia
        public List<Clientes> Clientes { get; set; }
    }
}
