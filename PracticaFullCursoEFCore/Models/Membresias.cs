﻿using System.ComponentModel.DataAnnotations;

namespace PracticaFullCursoEFCore.Models
{
    public class Membresias
    {
        [Key]
        public int ID_Membresia { get; set; }


        [StringLength(50)]
        [Display(Name = "Tipos de Membresia")]
        [Required(ErrorMessage = "Agregue una membresia")]
        public required string TípoMembresia { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]

        public DateTime FechaInicio { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de fin")]
        public DateTime FechaFin {  get; set; }


        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal CostoMensual { get; set; }


        //Esta es para la relación uno a uno
        public required Clientes Clientes { get; set; }
    }
}