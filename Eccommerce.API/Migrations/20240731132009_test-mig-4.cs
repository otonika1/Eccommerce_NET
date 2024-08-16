using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class testmig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_emptb_SuperHero",
                table: "supertb");

            migrationBuilder.RenameColumn(
                name: "SuperHero",
                table: "supertb",
                newName: "SuperHeroId");

            migrationBuilder.RenameIndex(
                name: "IX_supertb_SuperHero",
                table: "supertb",
                newName: "IX_supertb_SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_emptb_SuperHeroId",
                table: "supertb",
                column: "SuperHeroId",
                principalTable: "emptb",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_emptb_SuperHeroId",
                table: "supertb");

            migrationBuilder.RenameColumn(
                name: "SuperHeroId",
                table: "supertb",
                newName: "SuperHero");

            migrationBuilder.RenameIndex(
                name: "IX_supertb_SuperHeroId",
                table: "supertb",
                newName: "IX_supertb_SuperHero");

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_emptb_SuperHero",
                table: "supertb",
                column: "SuperHero",
                principalTable: "emptb",
                principalColumn: "Id");
        }
    }
}
