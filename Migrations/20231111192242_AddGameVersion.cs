using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReRoboRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddGameVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "GameVersion",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameVersion",
                table: "Games");
        }
    }
}
