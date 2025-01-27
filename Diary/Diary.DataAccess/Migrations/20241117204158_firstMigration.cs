using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diary.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryOwners",
                columns: table => new
                {
                    DiaryOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryOwners", x => x.DiaryOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiaryOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.DiaryId);
                    table.ForeignKey(
                        name: "FK_Diaries_DiaryOwners_DiaryOwnerId",
                        column: x => x.DiaryOwnerId,
                        principalTable: "DiaryOwners",
                        principalColumn: "DiaryOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaryLines",
                columns: table => new
                {
                    DiaryLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    HabitId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryLines", x => x.DiaryLineId);
                    table.ForeignKey(
                        name: "FK_DiaryLines_Diaries_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diaries",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_DiaryOwnerId",
                table: "Diaries",
                column: "DiaryOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryLines_DiaryId",
                table: "DiaryLines",
                column: "DiaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryLines");

            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "DiaryOwners");
        }
    }
}
