using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class firestBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DelayProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAfterATime = table.Column<bool>(type: "boolean", nullable: false),
                    AfterTime = table.Column<int>(type: "integer", nullable: false),
                    IsEndless = table.Column<bool>(type: "boolean", nullable: false),
                    DurationTime = table.Column<int>(type: "integer", nullable: false),
                    NameType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelayProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepetitionProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxCountPositive = table.Column<int>(type: "integer", nullable: false),
                    MaxCountNegative = table.Column<int>(type: "integer", nullable: false),
                    IsLimit = table.Column<bool>(type: "boolean", nullable: false),
                    CountLimit = table.Column<int>(type: "integer", nullable: false),
                    NameType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepetitionProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusString = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TitleValue = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TitleCheck = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TitleReportField = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TagsString = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitlePositive = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TitleNegative = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NameType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeResetIntervalProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Options = table.Column<int>(type: "integer", nullable: false),
                    TimeTheDay = table.Column<int>(type: "integer", nullable: false),
                    WeekDays = table.Column<int>(type: "integer", nullable: false),
                    NumberDayOfTheMonth = table.Column<int>(type: "integer", nullable: false),
                    NameType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeResetIntervalProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Persons_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Options = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TemplateValuesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", maxLength: 25000, nullable: true),
                    TitlesCheck = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Signatures_TemplateValuesId",
                        column: x => x.TemplateValuesId,
                        principalTable: "Signatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    Options = table.Column<int>(type: "integer", nullable: false),
                    DelayId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeResetIntervalId = table.Column<Guid>(type: "uuid", nullable: false),
                    RepetitionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habits_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_DelayProperties_DelayId",
                        column: x => x.DelayId,
                        principalTable: "DelayProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_Persons_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_RepetitionProperties_RepetitionId",
                        column: x => x.RepetitionId,
                        principalTable: "RepetitionProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_TimeResetIntervalProperties_TimeResetIntervalId",
                        column: x => x.TimeResetIntervalId,
                        principalTable: "TimeResetIntervalProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Вags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    HabitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Options = table.Column<int>(type: "integer", nullable: false),
                    CostOfWinning = table.Column<int>(type: "integer", nullable: false),
                    Forfeit = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<int>(type: "integer", nullable: false),
                    Falls = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Вags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Вags_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Вags_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Вags_HabitId",
                table: "Вags",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_Вags_RoomId1",
                table: "Вags",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TemplateValuesId",
                table: "Cards",
                column: "TemplateValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_CardId",
                table: "Habits",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_DelayId",
                table: "Habits",
                column: "DelayId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_OwnerId",
                table: "Habits",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_RepetitionId",
                table: "Habits",
                column: "RepetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_RoomId1",
                table: "Habits",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_TimeResetIntervalId",
                table: "Habits",
                column: "TimeResetIntervalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ManagerId",
                table: "Rooms",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Вags");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "DelayProperties");

            migrationBuilder.DropTable(
                name: "RepetitionProperties");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "TimeResetIntervalProperties");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
