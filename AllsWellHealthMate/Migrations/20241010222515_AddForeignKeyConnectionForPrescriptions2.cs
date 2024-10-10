using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyConnectionForPrescriptions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ProviderId",
                table: "Prescriptions",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Providers_ProviderId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_ProviderId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Prescriptions");
        }
    }
}
