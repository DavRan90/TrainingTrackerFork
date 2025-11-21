using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class MakeActivityAbstract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActivityDate",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ActivityType",
                table: "Activities",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AverageCadence",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AverageHeartRate",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaloriesBurned",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxHeartRate",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalTimeInSeconds",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AverageCadence",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "AverageHeartRate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CaloriesBurned",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MaxHeartRate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TotalTimeInSeconds",
                table: "Activities");
        }
    }
}
