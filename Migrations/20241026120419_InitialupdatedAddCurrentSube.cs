using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cargo.Migrations
{
    /// <inheritdoc />
    public partial class InitialupdatedAddCurrentSube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "currentSube",
                table: "Cargos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentSube",
                table: "Cargos");
        }
    }
}
