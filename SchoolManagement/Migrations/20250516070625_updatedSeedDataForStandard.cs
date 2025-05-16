using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedDataForStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 0, 0, 4 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 0, 0, 4 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 0, 0, 4 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 0, 0, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 2, 5000, null });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 2, 5000, null });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 2, 5000, null });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth", "SessionYearId" },
                values: new object[] { 2, 5000, null });
        }
    }
}
