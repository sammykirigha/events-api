using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eventsApi.Migrations
{
    /// <inheritdoc />
    public partial class migrationbc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees");

            migrationBuilder.DropIndex(
                name: "IX_EventAttendees_AttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropIndex(
                name: "IX_EventAttendees_EventId",
                table: "EventAttendees");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventAttendees");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_EventsEventId",
                table: "EventAttendees",
                column: "EventsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeesAttendeeId",
                table: "EventAttendees",
                column: "AttendeesAttendeeId",
                principalTable: "Attendees",
                principalColumn: "AttendeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Events_EventsEventId",
                table: "EventAttendees",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeesAttendeeId",
                table: "EventAttendees");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAttendees_Events_EventsEventId",
                table: "EventAttendees");

            migrationBuilder.DropIndex(
                name: "IX_EventAttendees_EventsEventId",
                table: "EventAttendees");

            migrationBuilder.AddColumn<int>(
                name: "AttendeeId",
                table: "EventAttendees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventAttendees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_AttendeeId",
                table: "EventAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_EventId",
                table: "EventAttendees",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Attendees_AttendeeId",
                table: "EventAttendees",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "AttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAttendees_Events_EventId",
                table: "EventAttendees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }
    }
}
