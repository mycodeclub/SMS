using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class nowAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SessionFee",
                keyColumn: "UniqueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SessionFee",
                keyColumn: "UniqueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SessionFee",
                keyColumn: "UniqueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SessionFee",
                keyColumn: "UniqueId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "BillingCycle",
                table: "Standards");

            migrationBuilder.DropColumn(
                name: "FeeAmountPerMonth",
                table: "Standards");

            migrationBuilder.CreateTable(
                name: "FeeType",
                columns: table => new
                {
                    FeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    ApplicableFromMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeType", x => x.FeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StandardFee",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    FeeTypeId = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFee", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_StandardFee_FeeType_FeeTypeId",
                        column: x => x.FeeTypeId,
                        principalTable: "FeeType",
                        principalColumn: "FeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardFee_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FeeType",
                columns: new[] { "FeeTypeId", "ApplicableFromMonth", "DueDate", "Frequency", "IsOptional", "IsRecurring", "Name" },
                values: new object[,]
                {
                    { 1, 3, 7, 12, false, false, "Admission Fee" },
                    { 2, 3, 7, 1, false, true, "Tuition Fee" },
                    { 3, 3, 7, 6, false, true, "Semester Fee" },
                    { 4, 3, 7, 12, false, false, "Stationery Fee" },
                    { 5, 3, 0, 1, true, true, "Day Care" },
                    { 6, 6, 0, 12, true, false, "Summer Camping" }
                });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "StandardFee",
                columns: new[] { "UniqueId", "Amount", "DueDate", "FeeTypeId", "Frequency", "StandardId" },
                values: new object[,]
                {
                    { 1, 4000m, null, 1, 4, 2 },
                    { 2, 4000m, null, 2, 1, 2 },
                    { 3, 4000m, null, 3, 3, 2 },
                    { 4, 4000m, null, 4, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardFee_FeeTypeId",
                table: "StandardFee",
                column: "FeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFee_StandardId",
                table: "StandardFee",
                column: "StandardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardFee");

            migrationBuilder.DropTable(
                name: "FeeType");

            migrationBuilder.AddColumn<int>(
                name: "BillingCycle",
                table: "Standards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeeAmountPerMonth",
                table: "Standards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "SessionFee",
                columns: new[] { "UniqueId", "ActivityFee", "AdmissionFee", "AnnualCharges", "ComputerFee", "Description", "ExaminationFee", "FeeType", "MiscellaneousFee", "SessionId", "SportsFee", "StandardId", "TransportFee", "TuitionFee" },
                values: new object[,]
                {
                    { 1, 0m, 0m, 0m, 0m, "", 0m, "Admission Fee", 0m, 4, 0m, null, 0m, 0m },
                    { 2, 0m, 0m, 0m, 0m, "", 0m, "Tuition Fee", 0m, 4, 0m, null, 0m, 0m },
                    { 3, 0m, 0m, 0m, 0m, "", 0m, "Semester Fee", 0m, 4, 0m, null, 0m, 0m },
                    { 4, 0m, 0m, 0m, 0m, "", 0m, "Other Fee", 0m, 4, 0m, null, 0m, 0m }
                });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "SessionYears",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Standards",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "BillingCycle", "FeeAmountPerMonth" },
                values: new object[] { 0, 0 });
        }
    }
}
