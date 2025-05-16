using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "StandardFees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "StandardFees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "Frequency",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "Frequency",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "Frequency",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "Frequency",
                value: 4);
        }
    }
}
