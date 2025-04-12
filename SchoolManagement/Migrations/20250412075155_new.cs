using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentUniqueId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentUniqueId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentUniqueId",
                table: "Parents",
                column: "StudentUniqueId",
                principalTable: "Students",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentUniqueId",
                table: "Parents");

            migrationBuilder.AlterColumn<int>(
                name: "StudentUniqueId",
                table: "Parents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentUniqueId",
                table: "Parents",
                column: "StudentUniqueId",
                principalTable: "Students",
                principalColumn: "UniqueId");
        }
    }
}
