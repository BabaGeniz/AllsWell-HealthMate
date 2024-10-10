using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class newColumnForHealthRecordandProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "HealthRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "HealthRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "HealthRecords",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "HealthRecords");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
