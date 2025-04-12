using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStuParentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationWithStudent",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "RelationId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_RelationId",
                table: "Parents",
                column: "RelationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Relations_RelationId",
                table: "Parents",
                column: "RelationId",
                principalTable: "Relations",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Relations_RelationId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_RelationId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "RelationId",
                table: "Parents");

            migrationBuilder.AddColumn<string>(
                name: "RelationWithStudent",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
