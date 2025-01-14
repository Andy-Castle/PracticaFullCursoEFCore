using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFullCursoEFCore.Models
{
    public class Pedidos
    {
        [Key]
        public int ID_Pedido { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Pedido")]
        public DateTime FechaPedido { get; set; }


        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total {  get; set; }


        //Para la relación uno a muchos Pedido - Cliente
        [ForeignKey("Clientes")]
        public int ID_Cliente { get; set; }
        public required Clientes Clientes { get; set; }


        //Para que exista la relación de muchos a muchos Pedido - PedidoProducto - Producto
        public required ICollection<PedidoProductos> ProductoPedidos { get; set; }
    }
}
