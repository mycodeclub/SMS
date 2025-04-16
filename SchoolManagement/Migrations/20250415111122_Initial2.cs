using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowMultiple",
                table: "Relations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 1,
                column: "AllowMultiple",
                value: false);

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 2,
                column: "AllowMultiple",
                value: false);

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { false, "GrandFather" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { false, "GrandMother" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 5,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { false, "MaternalMother" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 6,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { false, "MaternalFather" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 7,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { true, "Sister" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 8,
                columns: new[] { "AllowMultiple", "RelationName" },
                values: new object[] { true, "Brother" });

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 9,
                column: "AllowMultiple",
                value: true);

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 10,
                column: "AllowMultiple",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowMultiple",
                table: "Relations");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 3,
                column: "RelationName",
                value: "Sister");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 4,
                column: "RelationName",
                value: "Brother");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 5,
                column: "RelationName",
                value: "GrandFather");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 6,
                column: "RelationName",
                value: "GrandMother");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 7,
                column: "RelationName",
                value: "MaternalMother");

            migrationBuilder.UpdateData(
                table: "Relations",
                keyColumn: "UniqueId",
                keyValue: 8,
                column: "RelationName",
                value: "MaternalFather");
        }
    }
}
