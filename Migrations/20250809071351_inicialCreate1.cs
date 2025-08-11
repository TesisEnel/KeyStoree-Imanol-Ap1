using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations
{
    /// <inheritdoc />
    public partial class inicialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsTemaPersonalizado",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "NombreTema",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Productos");

            migrationBuilder.AddColumn<bool>(
                name: "EsTemaPersonalizado",
                table: "Productos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NombreTema",
                table: "Productos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
