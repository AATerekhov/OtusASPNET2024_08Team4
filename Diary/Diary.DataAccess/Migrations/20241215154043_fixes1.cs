using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fixes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HabitId",
                table: "DiaryLines",
                newName: "EntityId");

            migrationBuilder.AddColumn<int>(
                name: "entityType",
                table: "DiaryLines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Diaries",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "entityType",
                table: "DiaryLines");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Diaries");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "DiaryLines",
                newName: "HabitId");
        }
    }
}
