using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class nowAddedDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardFee_FeeType_FeeTypeId",
                table: "StandardFee");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardFee_Standards_StandardId",
                table: "StandardFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardFee",
                table: "StandardFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeType",
                table: "FeeType");

            migrationBuilder.RenameTable(
                name: "StandardFee",
                newName: "StandardFees");

            migrationBuilder.RenameTable(
                name: "FeeType",
                newName: "FeeTypes");

            migrationBuilder.RenameIndex(
                name: "IX_StandardFee_StandardId",
                table: "StandardFees",
                newName: "IX_StandardFees_StandardId");

            migrationBuilder.RenameIndex(
                name: "IX_StandardFee_FeeTypeId",
                table: "StandardFees",
                newName: "IX_StandardFees_FeeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardFees",
                table: "StandardFees",
                column: "UniqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes",
                column: "FeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardFees_FeeTypes_FeeTypeId",
                table: "StandardFees",
                column: "FeeTypeId",
                principalTable: "FeeTypes",
                principalColumn: "FeeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardFees_Standards_StandardId",
                table: "StandardFees",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardFees_FeeTypes_FeeTypeId",
                table: "StandardFees");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardFees_Standards_StandardId",
                table: "StandardFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardFees",
                table: "StandardFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeeTypes",
                table: "FeeTypes");

            migrationBuilder.RenameTable(
                name: "StandardFees",
                newName: "StandardFee");

            migrationBuilder.RenameTable(
                name: "FeeTypes",
                newName: "FeeType");

            migrationBuilder.RenameIndex(
                name: "IX_StandardFees_StandardId",
                table: "StandardFee",
                newName: "IX_StandardFee_StandardId");

            migrationBuilder.RenameIndex(
                name: "IX_StandardFees_FeeTypeId",
                table: "StandardFee",
                newName: "IX_StandardFee_FeeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardFee",
                table: "StandardFee",
                column: "UniqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeeType",
                table: "FeeType",
                column: "FeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardFee_FeeType_FeeTypeId",
                table: "StandardFee",
                column: "FeeTypeId",
                principalTable: "FeeType",
                principalColumn: "FeeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardFee_Standards_StandardId",
                table: "StandardFee",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
