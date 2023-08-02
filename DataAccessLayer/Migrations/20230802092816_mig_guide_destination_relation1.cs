using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_guide_destination_relation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_guideID",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "guideID",
                table: "Destinations",
                newName: "GuideID");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_guideID",
                table: "Destinations",
                newName: "IX_Destinations_GuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuideID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_GuideID",
                table: "Destinations");

            migrationBuilder.RenameColumn(
                name: "GuideID",
                table: "Destinations",
                newName: "guideID");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_GuideID",
                table: "Destinations",
                newName: "IX_Destinations_guideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_guideID",
                table: "Destinations",
                column: "guideID",
                principalTable: "Guides",
                principalColumn: "GuideID");
        }
    }
}
