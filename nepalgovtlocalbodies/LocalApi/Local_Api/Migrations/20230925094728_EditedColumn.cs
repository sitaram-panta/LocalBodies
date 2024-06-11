using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Local_Api.Migrations
{
    /// <inheritdoc />
    public partial class EditedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldDistrictTitle",
                table: "OldDistricts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldDistrictTitle",
                table: "OldDistricts");
        }
    }
}
