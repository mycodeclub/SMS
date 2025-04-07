using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class seedsession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SessionYears",
                columns: new[] { "UniqueId", "EndDate", "SessionName", "StartDate" },
                values: new object[] { 1, new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025-2026", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 1);
        }
    }
}
