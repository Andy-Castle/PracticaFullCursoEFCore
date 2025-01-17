﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PracticaFullCursoEFCore.Models
{
    public class Clientes
    {
        [Key]
        public int  ID_Cliente {  get; set; }


        [StringLength(100)]
        [Display(Name ="Nombre del cliente")]
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }


        [StringLength(100)]
        [Required]
        [EmailAddress(ErrorMessage ="Porfavor ingrese un email valido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Correo Electronico")]
        public string Correo { get; set; }


        [Phone]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [DefaultValue("##########")]
        public string Telefono { get; set; } = "0000000000";


        [StringLength(200)]
        [DefaultValue("Sin dirección")]
        public string Direccion { get; set; } = "Sin dirección";

        //Esta es para la relación uno a Muchos
        [ForeignKey("Membresias")]
        public int ID_Membresia { get; set; }
        public  Membresias Membresias { get; set; }


        //Esta es para la relación uno a muchos Cliente - Pedido
        public  List<Pedidos> Pedidos { get; set; }
    }
}
