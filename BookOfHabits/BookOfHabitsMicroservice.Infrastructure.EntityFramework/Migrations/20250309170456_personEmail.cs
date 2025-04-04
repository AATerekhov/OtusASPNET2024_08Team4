using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class personEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Rooms_RoomId1",
                table: "Habits");

            migrationBuilder.RenameColumn(
                name: "RoomId1",
                table: "Habits",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_RoomId1",
                table: "Habits",
                newName: "IX_Habits_RoomId");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Persons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Rooms_RoomId",
                table: "Habits",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Rooms_RoomId",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Habits",
                newName: "RoomId1");

            migrationBuilder.RenameIndex(
                name: "IX_Habits_RoomId",
                table: "Habits",
                newName: "IX_Habits_RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Rooms_RoomId1",
                table: "Habits",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
