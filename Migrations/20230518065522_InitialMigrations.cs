using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eventsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EventDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendeeEvents",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeEvents", x => new { x.AttendeeId, x.EventId });
                    table.ForeignKey(
                        name: "FK_AttendeeEvents_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendeeEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "Speaker" },
                values: new object[,]
                {
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "flora@gmail.com", "Flora", "Kirigha", "098767564", "Yes" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "john@gmail.com", "John", "Katua", "098767564", "No" },
                    { new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"), "synthia@gmail.com", "Synthia", "Sau", "098767564", "No" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "sammy@gmail.com", "Samuel", "Kirigha", "098767564", "Yes" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "dorcis@gmail.com", "Dorcis", "Kirigha", "098767564", "No" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "Description", "EventDate", "EventName", "Location" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), 100, "A Friend wedding", new DateTimeOffset(new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Wedding", "Nyeri" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), 50, "Friend birthday party", new DateTimeOffset(new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Birthday", "Nairobi" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), 150, "Farewell party for a friend", new DateTimeOffset(new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Farewell", "Voi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeEvents_EventId",
                table: "AttendeeEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeEvents");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
