using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReRoboRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAndMoreStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NormalizedGameName",
                table: "Games",
                newName: "GameAcronym");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameAcronym",
                table: "Games",
                newName: "NormalizedGameName");
        }
    }
}
