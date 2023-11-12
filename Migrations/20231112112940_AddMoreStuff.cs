using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReRoboRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Games",
                newName: "GameName");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedGameName",
                table: "Games",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedGameName",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameName",
                table: "Games",
                newName: "Title");
        }
    }
}
