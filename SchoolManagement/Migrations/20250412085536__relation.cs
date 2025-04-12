using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class _relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "UniqueId", "RelationName" },
                values: new object[,]
                {
                    { 1, "Mother" },
                    { 2, "Father" },
                    { 3, "Sister" },
                    { 4, "Brother" },
                    { 5, "GrandFather" },
                    { 6, "GrandMother" },
                    { 7, "MaternalMother" },
                    { 8, "MaternalFather" },
                    { 9, "Uncle" },
                    { 10, "Aunty" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 10);
        }
    }
}
