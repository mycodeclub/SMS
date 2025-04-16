using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class Addressaddstudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeAddressUniqueId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_HomeAddressUniqueId",
                table: "Students",
                column: "HomeAddressUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_HomeAddressUniqueId",
                table: "Students",
                column: "HomeAddressUniqueId",
                principalTable: "Addresses",
                principalColumn: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_HomeAddressUniqueId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_HomeAddressUniqueId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HomeAddressUniqueId",
                table: "Students");
        }
    }
}
