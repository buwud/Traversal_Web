using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_guide_destination_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "guideID",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_guideID",
                table: "Destinations",
                column: "guideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_guideID",
                table: "Destinations",
                column: "guideID",
                principalTable: "Guides",
                principalColumn: "GuideID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_guideID",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_guideID",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "guideID",
                table: "Destinations");
        }
    }
}
