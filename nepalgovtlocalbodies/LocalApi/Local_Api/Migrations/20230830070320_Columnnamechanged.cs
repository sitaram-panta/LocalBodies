using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Local_Api.Migrations
{
    /// <inheritdoc />
    public partial class Columnnamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OldMunicipalityId",
                table: "OldMunicipalities",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OldMunicipalities",
                newName: "OldMunicipalityId");
        }
    }
}
