using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class minorChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrescribingDoctor",
                table: "Prescriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PrescribingDoctor",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id");
        }
    }
}
