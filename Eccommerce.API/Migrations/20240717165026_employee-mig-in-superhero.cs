using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eccommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class employeemiginsuperhero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
