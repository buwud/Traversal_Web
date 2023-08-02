using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_dest_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Destinations_DestinationID1",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_DestinationID1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DestinationID1",
                table: "Destinations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Destinations",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "DestinationID1",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_DestinationID1",
                table: "Destinations",
                column: "DestinationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Destinations_DestinationID1",
                table: "Destinations",
                column: "DestinationID1",
                principalTable: "Destinations",
                principalColumn: "DestinationID");
        }
    }
}
