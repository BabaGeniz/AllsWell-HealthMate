using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnsHealthRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodPressure",
                table: "HealthRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cholestrol",
                table: "HealthRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlucoseLevel",
                table: "HealthRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HeartRate",
                table: "HealthRecords",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "Cholestrol",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "GlucoseLevel",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "HealthRecords");
        }
    }
}
