using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticaFullCursoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class FixMembresiasPropiedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TípoMembresia",
                table: "Membresias",
                newName: "TipoMembresia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoMembresia",
                table: "Membresias",
                newName: "TípoMembresia");
        }
    }
}
