using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedSessionIdInStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionYearId",
                table: "Standards",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "SessionYearId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "SessionYearId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "SessionYearId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "SessionYearId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_SessionYearId",
                table: "Standards",
                column: "SessionYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Standards_SessionYears_SessionYearId",
                table: "Standards",
                column: "SessionYearId",
                principalTable: "SessionYears",
                principalColumn: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Standards_SessionYears_SessionYearId",
                table: "Standards");

            migrationBuilder.DropIndex(
                name: "IX_Standards_SessionYearId",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "SessionYearId",
                table: "Standards");
        }
    }
}
