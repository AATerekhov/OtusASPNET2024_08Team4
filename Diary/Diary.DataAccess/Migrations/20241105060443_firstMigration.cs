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
                name: "Users",
                columns: table => new
                {
                    JournalOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.JournalOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "UserJournals",
                columns: table => new
                {
                    JournalId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    JournalOwnerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournals", x => x.JournalId);
                    table.ForeignKey(
                        name: "FK_UserJournals_Users_JournalOwnerId",
                        column: x => x.JournalOwnerId,
                        principalTable: "Users",
                        principalColumn: "JournalOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJournalLines",
                columns: table => new
                {
                    JournalLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    JournalId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedEntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    RelatedEntityType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJournalLines", x => x.JournalLineId);
                    table.ForeignKey(
                        name: "FK_UserJournalLines_UserJournals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "UserJournals",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserJournalLines_JournalId",
                table: "UserJournalLines",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJournals_JournalOwnerId",
                table: "UserJournals",
                column: "JournalOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserJournalLines");

            migrationBuilder.DropTable(
                name: "UserJournals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
