using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class testmig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_emptb_SuperHeroId",
                table: "supertb");

            migrationBuilder.DropIndex(
                name: "IX_supertb_SuperHeroId",
                table: "supertb");

            migrationBuilder.DropColumn(
                name: "SuperHeroId",
                table: "supertb");

            migrationBuilder.CreateIndex(
                name: "IX_supertb_EmployeeId",
                table: "supertb",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_emptb_EmployeeId",
                table: "supertb",
                column: "EmployeeId",
                principalTable: "emptb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_supertb_emptb_EmployeeId",
                table: "supertb");

            migrationBuilder.DropIndex(
                name: "IX_supertb_EmployeeId",
                table: "supertb");

            migrationBuilder.AddColumn<int>(
                name: "SuperHeroId",
                table: "supertb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_supertb_SuperHeroId",
                table: "supertb",
                column: "SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_supertb_emptb_SuperHeroId",
                table: "supertb",
                column: "SuperHeroId",
                principalTable: "emptb",
                principalColumn: "Id");
        }
    }
}
