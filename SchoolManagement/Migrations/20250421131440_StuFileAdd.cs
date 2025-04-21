using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class StuFileAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AadhaarNumber",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AadharFileUrl",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanFileUrl",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanNumber",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotosFileUrl",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AadhaarNumber",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "AadharFileUrl",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PanFileUrl",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PanNumber",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PhotosFileUrl",
                table: "Parents");
        }
    }
}
