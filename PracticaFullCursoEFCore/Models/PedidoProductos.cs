using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFullCursoEFCore.Models
{
    public class PedidoProductos
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Pedidos")]
        public int ID_Pedido { get; set; }

        [ForeignKey("Productos")]
        public int ID_Producto { get; set; }

        public  Pedidos Pedidos { get; set; }
        public Productos Productos { get; set; }    

    }
}
