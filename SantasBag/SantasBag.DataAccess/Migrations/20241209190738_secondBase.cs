using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantasBag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class secondBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InstantBuy",
                table: "Rewards",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstantBuy",
                table: "Rewards");
        }
    }
}
