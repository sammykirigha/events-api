using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eventsApi.Migrations
{
    /// <inheritdoc />
    public partial class addedmorefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventReminderCheck",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsEmailSent",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                columns: new[] { "EventReminderCheck", "IsEmailSent" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                columns: new[] { "EventReminderCheck", "IsEmailSent" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                columns: new[] { "EventReminderCheck", "IsEmailSent" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                columns: new[] { "EventReminderCheck", "IsEmailSent" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                columns: new[] { "EventReminderCheck", "IsEmailSent" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventReminderCheck",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "IsEmailSent",
                table: "Attendees");
        }
    }
}
