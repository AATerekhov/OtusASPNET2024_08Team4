using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedHabitAndHabitStateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diaries_DiaryOwners_DiaryOwnerId",
                table: "Diaries");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaryLines_Diaries_DiaryId",
                table: "DiaryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaryOwners",
                table: "DiaryOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaryLines",
                table: "DiaryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diaries",
                table: "Diaries");

            migrationBuilder.RenameTable(
                name: "DiaryOwners",
                newName: "HabitDiaryOwners");

            migrationBuilder.RenameTable(
                name: "DiaryLines",
                newName: "HabitDiaryLines");

            migrationBuilder.RenameTable(
                name: "Diaries",
                newName: "HabitDiaries");

            migrationBuilder.RenameIndex(
                name: "IX_DiaryLines_DiaryId",
                table: "HabitDiaryLines",
                newName: "IX_HabitDiaryLines_DiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Diaries_DiaryOwnerId",
                table: "HabitDiaries",
                newName: "IX_HabitDiaries_DiaryOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitDiaryOwners",
                table: "HabitDiaryOwners",
                column: "DiaryOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitDiaryLines",
                table: "HabitDiaryLines",
                column: "DiaryLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitDiaries",
                table: "HabitDiaries",
                column: "DiaryId");

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    HabitId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.HabitId);
                    table.ForeignKey(
                        name: "FK_Habits_HabitDiaries_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "HabitDiaries",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabitStates",
                columns: table => new
                {
                    HabitStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    HabitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Tag = table.Column<int>(type: "integer", nullable: false),
                    TitleValue = table.Column<int>(type: "integer", nullable: false),
                    TitleCheck = table.Column<bool>(type: "boolean", nullable: false),
                    TextPositive = table.Column<int>(type: "integer", nullable: false),
                    TitleReportField = table.Column<string>(type: "text", nullable: true),
                    TextNegative = table.Column<int>(type: "integer", nullable: false),
                    IsNotified = table.Column<bool>(type: "boolean", nullable: false),
                    isRated = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitStates", x => x.HabitStateId);
                    table.ForeignKey(
                        name: "FK_HabitStates_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "HabitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_DiaryId",
                table: "Habits",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitStates_HabitId",
                table: "HabitStates",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitDiaries_HabitDiaryOwners_DiaryOwnerId",
                table: "HabitDiaries",
                column: "DiaryOwnerId",
                principalTable: "HabitDiaryOwners",
                principalColumn: "DiaryOwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitDiaryLines_HabitDiaries_DiaryId",
                table: "HabitDiaryLines",
                column: "DiaryId",
                principalTable: "HabitDiaries",
                principalColumn: "DiaryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitDiaries_HabitDiaryOwners_DiaryOwnerId",
                table: "HabitDiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitDiaryLines_HabitDiaries_DiaryId",
                table: "HabitDiaryLines");

            migrationBuilder.DropTable(
                name: "HabitStates");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitDiaryOwners",
                table: "HabitDiaryOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitDiaryLines",
                table: "HabitDiaryLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitDiaries",
                table: "HabitDiaries");

            migrationBuilder.RenameTable(
                name: "HabitDiaryOwners",
                newName: "DiaryOwners");

            migrationBuilder.RenameTable(
                name: "HabitDiaryLines",
                newName: "DiaryLines");

            migrationBuilder.RenameTable(
                name: "HabitDiaries",
                newName: "Diaries");

            migrationBuilder.RenameIndex(
                name: "IX_HabitDiaryLines_DiaryId",
                table: "DiaryLines",
                newName: "IX_DiaryLines_DiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_HabitDiaries_DiaryOwnerId",
                table: "Diaries",
                newName: "IX_Diaries_DiaryOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaryOwners",
                table: "DiaryOwners",
                column: "DiaryOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaryLines",
                table: "DiaryLines",
                column: "DiaryLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diaries",
                table: "Diaries",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diaries_DiaryOwners_DiaryOwnerId",
                table: "Diaries",
                column: "DiaryOwnerId",
                principalTable: "DiaryOwners",
                principalColumn: "DiaryOwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiaryLines_Diaries_DiaryId",
                table: "DiaryLines",
                column: "DiaryId",
                principalTable: "Diaries",
                principalColumn: "DiaryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
