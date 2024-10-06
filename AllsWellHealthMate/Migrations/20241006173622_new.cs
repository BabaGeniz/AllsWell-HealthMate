using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Providers",
                newName: "HospitalAffiliation");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Providers");

            migrationBuilder.RenameColumn(
                name: "HospitalAffiliation",
                table: "Providers",
                newName: "FirstName");
        }
    }
}
