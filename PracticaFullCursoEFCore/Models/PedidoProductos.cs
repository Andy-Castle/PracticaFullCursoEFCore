using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaFullCursoEFCore.Models
{
    public class PedidoProductos
    {
        [ForeignKey("Pedidos")]
        public int ID_Pedido { get; set; }

        [ForeignKey("Productos")]
        public int ID_Producto { get; set; }

        public required Pedidos Pedidos { get; set; }
        public required Productos Productos { get; set; }    

    }
}
