using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class addedMissing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staffs_SessionYears_SessionYearId",
                table: "staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staffs",
                table: "staffs");

            migrationBuilder.DropIndex(
                name: "IX_staffs_SessionYearId",
                table: "staffs");

            migrationBuilder.DropColumn(
                name: "SessionYearId",
                table: "staffs");

            migrationBuilder.RenameTable(
                name: "staffs",
                newName: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "Qualification",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AadharFileUrl",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotosFileUrl",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "UniqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "AadharFileUrl",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "PhotosFileUrl",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "staffs");

            migrationBuilder.AlterColumn<string>(
                name: "Qualification",
                table: "staffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionYearId",
                table: "staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_staffs",
                table: "staffs",
                column: "UniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_SessionYearId",
                table: "staffs",
                column: "SessionYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_staffs_SessionYears_SessionYearId",
                table: "staffs",
                column: "SessionYearId",
                principalTable: "SessionYears",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
