using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class checkIfMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 3,
                columns: new[] { "Frequency", "Name" },
                values: new object[] { 3, "Development Fee" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 4,
                columns: new[] { "Frequency", "IsRecurring", "Name" },
                values: new object[] { 3, true, "Computer Lab Fee" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 5,
                columns: new[] { "DueDate", "Frequency", "IsOptional", "Name" },
                values: new object[] { 7, 3, false, "Library Fee" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 6,
                columns: new[] { "ApplicableFromMonth", "DueDate", "Frequency", "IsOptional", "IsRecurring", "Name" },
                values: new object[] { 3, 7, 3, false, true, "Sports Fee" });

            migrationBuilder.InsertData(
                table: "FeeTypes",
                columns: new[] { "FeeTypeId", "ApplicableFromMonth", "DueDate", "Frequency", "IsOptional", "IsRecurring", "Name" },
                values: new object[,]
                {
                    { 7, 3, 7, 3, false, true, "Activity Fee" },
                    { 8, 3, 7, 12, false, false, "Registration Fee" },
                    { 9, 3, 7, 6, false, false, "Examination Fee" },
                    { 10, 3, 7, 12, false, false, "Stationery Fee" },
                    { 11, 3, 7, 12, false, false, "Uniform Fee" },
                    { 12, 3, 7, 1, true, true, "Day Care" },
                    { 13, 3, 7, 1, true, true, "Transportation Fee" },
                    { 14, 6, 7, 12, true, false, "Summer Camp" },
                    { 15, 3, 7, 1, true, true, "Special Classes" },
                    { 16, 3, 7, 12, false, false, "Annual Function Fee" },
                    { 17, 3, 7, 12, false, false, "Sports Day Fee" },
                    { 18, 3, 7, 12, false, false, "Cultural Program Fee" }
                });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 5000m, 1 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 3000m, 1 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 1000m, 1 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 500m, 1 });

            migrationBuilder.InsertData(
                table: "StandardFees",
                columns: new[] { "UniqueId", "Amount", "DueDate", "FeeTypeId", "StandardId" },
                values: new object[,]
                {
                    { 5, 300m, null, 5, 1 },
                    { 6, 500m, null, 6, 1 },
                    { 15, 5500m, null, 1, 2 },
                    { 16, 3500m, null, 2, 2 },
                    { 17, 1200m, null, 3, 2 },
                    { 18, 600m, null, 4, 2 },
                    { 19, 400m, null, 5, 2 },
                    { 20, 600m, null, 6, 2 },
                    { 7, 500m, null, 7, 1 },
                    { 8, 1000m, null, 8, 1 },
                    { 9, 500m, null, 9, 1 },
                    { 10, 1000m, null, 10, 1 },
                    { 11, 2000m, null, 11, 1 },
                    { 12, 2000m, null, 12, 1 },
                    { 13, 1500m, null, 13, 1 },
                    { 14, 1000m, null, 16, 1 },
                    { 21, 600m, null, 7, 2 },
                    { 22, 1200m, null, 8, 2 },
                    { 23, 600m, null, 9, 2 },
                    { 24, 1200m, null, 10, 2 },
                    { 25, 2200m, null, 11, 2 },
                    { 26, 2200m, null, 12, 2 },
                    { 27, 1700m, null, 13, 2 },
                    { 28, 1200m, null, 16, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 3,
                columns: new[] { "Frequency", "Name" },
                values: new object[] { 6, "Semester Fee" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 4,
                columns: new[] { "Frequency", "IsRecurring", "Name" },
                values: new object[] { 12, false, "Stationery Fee" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 5,
                columns: new[] { "DueDate", "Frequency", "IsOptional", "Name" },
                values: new object[] { 0, 1, true, "Day Care" });

            migrationBuilder.UpdateData(
                table: "FeeTypes",
                keyColumn: "FeeTypeId",
                keyValue: 6,
                columns: new[] { "ApplicableFromMonth", "DueDate", "Frequency", "IsOptional", "IsRecurring", "Name" },
                values: new object[] { 6, 0, 12, true, false, "Summer Camping" });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 1,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 4000m, 2 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 2,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 4000m, 2 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 3,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 4000m, 2 });

            migrationBuilder.UpdateData(
                table: "StandardFees",
                keyColumn: "UniqueId",
                keyValue: 4,
                columns: new[] { "Amount", "StandardId" },
                values: new object[] { 4000m, 2 });
        }
    }
}
