using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagazineOwners",
                columns: table => new
                {
                    MagazineOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineOwners", x => x.MagazineOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    MagazineId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MagazineOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.MagazineId);
                    table.ForeignKey(
                        name: "FK_Magazines_MagazineOwners_MagazineOwnerId",
                        column: x => x.MagazineOwnerId,
                        principalTable: "MagazineOwners",
                        principalColumn: "MagazineOwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MagazineLine",
                columns: table => new
                {
                    MagazineLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    MagazineId = table.Column<Guid>(type: "uuid", nullable: false),
                    RewardId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagazineLine", x => x.MagazineLineId);
                    table.ForeignKey(
                        name: "FK_MagazineLine_Magazines_MagazineId",
                        column: x => x.MagazineId,
                        principalTable: "Magazines",
                        principalColumn: "MagazineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MagazineLine_MagazineId",
                table: "MagazineLine",
                column: "MagazineId");

            migrationBuilder.CreateIndex(
                name: "IX_Magazines_MagazineOwnerId",
                table: "Magazines",
                column: "MagazineOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MagazineLine");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "MagazineOwners");
        }
    }
}
