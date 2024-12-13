using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class aditedHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Cards_CardId",
                table: "Habits");

            migrationBuilder.AlterColumn<Guid>(
                name: "CardId",
                table: "Habits",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Cards_CardId",
                table: "Habits",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Cards_CardId",
                table: "Habits");

            migrationBuilder.AlterColumn<Guid>(
                name: "CardId",
                table: "Habits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Cards_CardId",
                table: "Habits",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
