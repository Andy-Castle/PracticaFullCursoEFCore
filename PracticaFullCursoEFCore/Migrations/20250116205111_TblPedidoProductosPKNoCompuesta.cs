using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class TblPedidoProductosPKNoCompuesta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProductos",
                table: "PedidoProductos");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PedidoProductos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProductos",
                table: "PedidoProductos",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProductos_ID_Pedido",
                table: "PedidoProductos",
                column: "ID_Pedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProductos",
                table: "PedidoProductos");

            migrationBuilder.DropIndex(
                name: "IX_PedidoProductos_ID_Pedido",
                table: "PedidoProductos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PedidoProductos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProductos",
                table: "PedidoProductos",
                columns: new[] { "ID_Pedido", "ID_Producto" });
        }
    }
}
