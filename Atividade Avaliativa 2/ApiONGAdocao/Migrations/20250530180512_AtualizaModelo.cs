using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiONGAdocao.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Peso",
                table: "Animais",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "DOUBLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Peso",
                table: "Animais",
                type: "DOUBLE",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
