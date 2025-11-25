using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCyclingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvarageWatts",
                table: "Activities",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvarageWatts",
                table: "Activities");
        }
    }
}
