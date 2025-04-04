using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookOfHabitsMicroservice.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class editedCardAndTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusString",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "TagsString",
                table: "Signatures");

            migrationBuilder.AddColumn<string>(
                name: "TitleFileReceiver",
                table: "Signatures",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleStatus",
                table: "Signatures",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleTags",
                table: "Signatures",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusString",
                table: "Cards",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TagsString",
                table: "Cards",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleFileReceiver",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "TitleStatus",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "TitleTags",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "StatusString",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "TagsString",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "StatusString",
                table: "Signatures",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TagsString",
                table: "Signatures",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
