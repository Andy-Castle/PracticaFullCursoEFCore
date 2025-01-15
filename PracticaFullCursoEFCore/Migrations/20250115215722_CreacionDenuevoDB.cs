using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDenuevoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    ID_Membresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMembresia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostoMensual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.ID_Membresia);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_Membresia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_Cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Membresias_ID_Membresia",
                        column: x => x.ID_Membresia,
                        principalTable: "Membresias",
                        principalColumn: "ID_Membresia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ID_Cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ID_Cliente",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProductos",
                columns: table => new
                {
                    ID_Pedido = table.Column<int>(type: "int", nullable: false),
                    ID_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProductos", x => new { x.ID_Pedido, x.ID_Producto });
                    table.ForeignKey(
                        name: "FK_PedidoProductos_Pedidos_ID_Pedido",
                        column: x => x.ID_Pedido,
                        principalTable: "Pedidos",
                        principalColumn: "ID_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProductos_Productos_ID_Producto",
                        column: x => x.ID_Producto,
                        principalTable: "Productos",
                        principalColumn: "ID_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Correo",
                table: "Clientes",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ID_Membresia",
                table: "Clientes",
                column: "ID_Membresia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProductos_ID_Producto",
                table: "PedidoProductos",
                column: "ID_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ID_Cliente",
                table: "Pedidos",
                column: "ID_Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProductos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Membresias");
        }
    }
}
