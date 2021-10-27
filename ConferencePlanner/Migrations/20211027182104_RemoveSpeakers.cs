using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConferencePlanner.Migrations
{
    public partial class RemoveSpeakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "AttendeeSession");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Email",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Attendees",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_SessionId",
                table: "Attendees",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Sessions_SessionId",
                table: "Attendees",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Sessions_SessionId",
                table: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_SessionId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Attendees");

            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "Sessions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttendeeSession",
                columns: table => new
                {
                    AttendeesId = table.Column<int>(type: "integer", nullable: false),
                    SessionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeSession", x => new { x.AttendeesId, x.SessionsId });
                    table.ForeignKey(
                        name: "FK_AttendeeSession_Attendees_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendeeSession_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerId",
                table: "Sessions",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeSession_SessionsId",
                table: "AttendeeSession",
                column: "SessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_Name",
                table: "Speakers",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
