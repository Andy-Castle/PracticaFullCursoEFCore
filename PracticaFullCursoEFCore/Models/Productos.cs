using System.ComponentModel.DataAnnotations;

namespace PracticaFullCursoEFCore.Models
{
    public class Productos
    {
        [Key]
        public int ID_Producto { get; set; }


        [StringLength(100)]
        [Display(Name = "Nombre del producto")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Nombre { get; set; }


        [StringLength(500)]
        [Display(Name = "Descripción del producto")]
        public string? Descripcion { get; set; }


        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }


        //Para que exista la relación de muchos a muchos Pedido - PedidoProducto - Producto
        public required ICollection<PedidoProductos> ProductoPedidos { get; set; }
    }
}
