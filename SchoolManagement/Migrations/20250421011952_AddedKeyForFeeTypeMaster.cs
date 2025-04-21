using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddedKeyForFeeTypeMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeeTypeMaster",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypeMaster", x => x.UniqueId);
                });

            migrationBuilder.InsertData(
                table: "FeeTypeMaster",
                columns: new[] { "UniqueId", "Description", "FeeType" },
                values: new object[,]
                {
                    { 1, "", "Admission Fee" },
                    { 2, "", "Tuition Fee" },
                    { 3, "", "Semester Fee" },
                    { 4, "", "Other Fee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeeTypeMaster");
        }
    }
}
