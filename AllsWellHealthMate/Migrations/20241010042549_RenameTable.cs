using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergy_HealthRecords_HealthRecordId",
                table: "Allergy");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_HealthRecords_HealthRecordId",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Allergy",
                newName: "Allergies");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_HealthRecordId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_HealthRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Allergy_HealthRecordId",
                table: "Allergies",
                newName: "IX_Allergies_HealthRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_HealthRecords_HealthRecordId",
                table: "Allergies",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_HealthRecords_HealthRecordId",
                table: "Prescriptions",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_HealthRecords_HealthRecordId",
                table: "Allergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_HealthRecords_HealthRecordId",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "Prescription");

            migrationBuilder.RenameTable(
                name: "Allergies",
                newName: "Allergy");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_HealthRecordId",
                table: "Prescription",
                newName: "IX_Prescription_HealthRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Allergies_HealthRecordId",
                table: "Allergy",
                newName: "IX_Allergy_HealthRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription",
                table: "Prescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_HealthRecords_HealthRecordId",
                table: "Allergy",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_HealthRecords_HealthRecordId",
                table: "Prescription",
                column: "HealthRecordId",
                principalTable: "HealthRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
