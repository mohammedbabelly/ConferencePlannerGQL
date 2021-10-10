using Microsoft.EntityFrameworkCore.Migrations;

namespace ConferencePlanner.Migrations
{
    public partial class RefactorAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker");

            migrationBuilder.DropTable(
                name: "SessionAttendee");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Username",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "SessionSpeaker",
                newName: "SpeakersId");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "SessionSpeaker",
                newName: "SessionsId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionSpeaker_SpeakerId",
                table: "SessionSpeaker",
                newName: "IX_SessionSpeaker_SpeakersId");

            migrationBuilder.RenameColumn(
                name: "Abstract",
                table: "Sessions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Attendees",
                newName: "Name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_Name",
                table: "Speakers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeSession_SessionsId",
                table: "AttendeeSession",
                column: "SessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionsId",
                table: "SessionSpeaker",
                column: "SessionsId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakersId",
                table: "SessionSpeaker",
                column: "SpeakersId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionsId",
                table: "SessionSpeaker");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakersId",
                table: "SessionSpeaker");

            migrationBuilder.DropTable(
                name: "AttendeeSession");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_Name",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Email",
                table: "Attendees");

            migrationBuilder.RenameColumn(
                name: "SpeakersId",
                table: "SessionSpeaker",
                newName: "SpeakerId");

            migrationBuilder.RenameColumn(
                name: "SessionsId",
                table: "SessionSpeaker",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionSpeaker_SpeakersId",
                table: "SessionSpeaker",
                newName: "IX_SessionSpeaker_SpeakerId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Sessions",
                newName: "Abstract");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Attendees",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Attendees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Attendees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SessionAttendee",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    AttendeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAttendee", x => new { x.SessionId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionAttendee_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Username",
                table: "Attendees",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendee_AttendeeId",
                table: "SessionAttendee",
                column: "AttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Sessions_SessionId",
                table: "SessionSpeaker",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionSpeaker_Speakers_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
