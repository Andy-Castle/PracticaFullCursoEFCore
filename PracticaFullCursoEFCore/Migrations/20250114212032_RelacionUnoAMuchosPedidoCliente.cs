using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class RelacionUnoAMuchosPedidoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Cliente",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ID_Cliente",
                table: "Pedidos",
                column: "ID_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ID_Cliente",
                table: "Pedidos",
                column: "ID_Cliente",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ID_Cliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ID_Cliente",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ID_Cliente",
                table: "Pedidos");
        }
    }
}
