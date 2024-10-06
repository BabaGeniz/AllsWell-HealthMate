using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    /// <inheritdoc />
    public partial class newColumnAfterReversal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Providers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Providers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
