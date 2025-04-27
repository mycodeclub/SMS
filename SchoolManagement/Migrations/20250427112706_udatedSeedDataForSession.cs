using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class udatedSeedDataForSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "IsAcitve", "SessionName" },
                values: new object[] { true, "Session 2025 - 26" });

            migrationBuilder.InsertData(
                table: "SessionYears",
                columns: new[] { "UniqueId", "CreatedDate", "EndDate", "IsAcitve", "IsDeleted", "SessionName", "StartDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2024 - 25", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2023 - 24", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2022 - 23", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "IsAcitve", "SessionName" },
                values: new object[] { false, "2025-2026" });
        }
    }
}
