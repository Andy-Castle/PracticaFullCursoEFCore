using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionDeRelacionClientesMembresias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membresias_Clientes_ID_Cliente",
                table: "Membresias");

            migrationBuilder.DropIndex(
                name: "IX_Membresias_ID_Cliente",
                table: "Membresias");

            migrationBuilder.DropColumn(
                name: "ID_Cliente",
                table: "Membresias");

            migrationBuilder.AddColumn<int>(
                name: "ID_Membresia",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ID_Membresia",
                table: "Clientes",
                column: "ID_Membresia");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Membresias_ID_Membresia",
                table: "Clientes",
                column: "ID_Membresia",
                principalTable: "Membresias",
                principalColumn: "ID_Membresia",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Membresias_ID_Membresia",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ID_Membresia",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ID_Membresia",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ID_Cliente",
                table: "Membresias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Membresias_ID_Cliente",
                table: "Membresias",
                column: "ID_Cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Membresias_Clientes_ID_Cliente",
                table: "Membresias",
                column: "ID_Cliente",
                principalTable: "Clientes",
                principalColumn: "ID_Cliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
