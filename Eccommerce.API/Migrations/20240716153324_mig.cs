using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_supertb_SuperHeroEntityId",
                table: "supertb");

            migrationBuilder.DropColumn(
                name: "EmployeeCount",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "SuperHeroEntityId",
                table: "supertb",
                newName: "SuperHero");

            migrationBuilder.RenameIndex(
                name: "IX_supertb_SuperHeroEntityId",
                table: "supertb",
                newName: "IX_supertb_SuperHero");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "supertb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_emptb_SuperHero",
                table: "supertb",
                column: "SuperHero",
                principalTable: "emptb",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_emptb_SuperHero",
                table: "supertb");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "supertb");

            migrationBuilder.RenameColumn(
                name: "SuperHero",
                table: "supertb",
                newName: "SuperHeroEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_supertb_SuperHero",
                table: "supertb",
                newName: "IX_supertb_SuperHeroEntityId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCount",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_supertb_SuperHeroEntityId",
                table: "supertb",
                column: "SuperHeroEntityId",
                principalTable: "supertb",
                principalColumn: "Id");
        }
    }
}
