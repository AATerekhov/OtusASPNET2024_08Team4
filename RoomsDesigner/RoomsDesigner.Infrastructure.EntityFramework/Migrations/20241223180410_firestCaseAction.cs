using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomsDesigner.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class firestCaseAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Cases_RoomId",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Participants",
                newName: "RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_RoomId",
                table: "Participants",
                newName: "IX_Participants_RoomId1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cases",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Cases_RoomId1",
                table: "Participants",
                column: "RoomId1",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Cases_RoomId1",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "RoomId1",
                table: "Participants",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_RoomId1",
                table: "Participants",
                newName: "IX_Participants_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Cases_RoomId",
                table: "Participants",
                column: "RoomId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
