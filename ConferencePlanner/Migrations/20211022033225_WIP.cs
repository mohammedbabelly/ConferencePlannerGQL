using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferencePlanner.Migrations
{
    public partial class WIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionSpeaker");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Sessions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions",
                column: "SpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Sessions");

            migrationBuilder.CreateTable(
                name: "SessionSpeaker",
                columns: table => new
                {
                    SessionsId = table.Column<int>(type: "integer", nullable: false),
                    SpeakersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSpeaker", x => new { x.SessionsId, x.SpeakersId });
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSpeaker_Speakers_SpeakersId",
                        column: x => x.SpeakersId,
                        principalTable: "Speakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SpeakersId",
                table: "SessionSpeaker",
                column: "SpeakersId");
        }
    }
}
