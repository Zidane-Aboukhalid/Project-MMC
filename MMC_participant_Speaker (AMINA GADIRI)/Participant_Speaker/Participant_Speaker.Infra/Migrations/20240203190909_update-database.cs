using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Participant_Speaker.Infra.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Speakers_SpeakerId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "LinkSms");

            migrationBuilder.RenameIndex(
                name: "IX_Links_SpeakerId",
                table: "LinkSms",
                newName: "IX_LinkSms_SpeakerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkSms",
                table: "LinkSms",
                column: "LinkSmId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkSms_Speakers_SpeakerId",
                table: "LinkSms",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkSms_Speakers_SpeakerId",
                table: "LinkSms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkSms",
                table: "LinkSms");

            migrationBuilder.RenameTable(
                name: "LinkSms",
                newName: "Links");

            migrationBuilder.RenameIndex(
                name: "IX_LinkSms_SpeakerId",
                table: "Links",
                newName: "IX_Links_SpeakerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "LinkSmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Speakers_SpeakerId",
                table: "Links",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
