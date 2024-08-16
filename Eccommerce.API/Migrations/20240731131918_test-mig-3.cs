using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class testmig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuperHeroId",
                table: "emptb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperHeroId",
                table: "emptb");
        }
    }
}
