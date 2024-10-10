using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyConnectionForPrescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrescribingDoctor",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrescribingDoctor",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
