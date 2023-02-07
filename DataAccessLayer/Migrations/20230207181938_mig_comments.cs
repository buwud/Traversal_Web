using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationID1",
                table: "Destinations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentState = table.Column<bool>(type: "bit", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Destinations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destinations",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_DestinationID1",
                table: "Destinations",
                column: "DestinationID1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DestinationID",
                table: "Comments",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Destinations_DestinationID1",
                table: "Destinations",
                column: "DestinationID1",
                principalTable: "Destinations",
                principalColumn: "DestinationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Destinations_DestinationID1",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_DestinationID1",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "DestinationID1",
                table: "Destinations");
        }
    }
}
