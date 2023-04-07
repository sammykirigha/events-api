﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eventsApi.Entities;

#nullable disable

namespace eventsApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230407030946_mappedrlship")]
    partial class mappedrlship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AttendeeEvent", b =>
                {
                    b.Property<int>("AttendeesAttendeeId")
                        .HasColumnType("int");

                    b.Property<int>("EventsEventId")
                        .HasColumnType("int");

                    b.HasKey("AttendeesAttendeeId", "EventsEventId");

                    b.HasIndex("EventsEventId");

                    b.ToTable("AttendeeEvent");

                    b.HasData(
                        new
                        {
                            AttendeesAttendeeId = 1,
                            EventsEventId = 1
                        },
                        new
                        {
                            AttendeesAttendeeId = 2,
                            EventsEventId = 1
                        },
                        new
                        {
                            AttendeesAttendeeId = 3,
                            EventsEventId = 1
                        },
                        new
                        {
                            AttendeesAttendeeId = 4,
                            EventsEventId = 2
                        },
                        new
                        {
                            AttendeesAttendeeId = 5,
                            EventsEventId = 2
                        },
                        new
                        {
                            AttendeesAttendeeId = 2,
                            EventsEventId = 2
                        },
                        new
                        {
                            AttendeesAttendeeId = 5,
                            EventsEventId = 3
                        },
                        new
                        {
                            AttendeesAttendeeId = 1,
                            EventsEventId = 3
                        },
                        new
                        {
                            AttendeesAttendeeId = 3,
                            EventsEventId = 3
                        });
                });

            modelBuilder.Entity("eventsApi.Models.Attendee", b =>
                {
                    b.Property<int>("AttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendeeId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendeeId");

                    b.ToTable("Attendees");

                    b.HasData(
                        new
                        {
                            AttendeeId = 1,
                            Email = "sammy@gmail.com",
                            FirstName = "Samuel",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "Yes"
                        },
                        new
                        {
                            AttendeeId = 2,
                            Email = "dorcis@gmail.com",
                            FirstName = "Dorcis",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "No"
                        },
                        new
                        {
                            AttendeeId = 3,
                            Email = "john@gmail.com",
                            FirstName = "John",
                            LastName = "Katua",
                            Phone = "098767564",
                            Speaker = "No"
                        },
                        new
                        {
                            AttendeeId = 4,
                            Email = "flora@gmail.com",
                            FirstName = "Flora",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "Yes"
                        },
                        new
                        {
                            AttendeeId = 5,
                            Email = "synthia@gmail.com",
                            FirstName = "Synthia",
                            LastName = "Sau",
                            Phone = "098767564",
                            Speaker = "No"
                        });
                });

            modelBuilder.Entity("eventsApi.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<int?>("Capacity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Capacity = 100,
                            Description = "A Friend wedding",
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2011),
                            EventName = "Wedding",
                            Location = "Nyeri"
                        },
                        new
                        {
                            EventId = 2,
                            Capacity = 50,
                            Description = "Friend birthday party",
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007),
                            EventName = "Birthday",
                            Location = "Nairobi"
                        },
                        new
                        {
                            EventId = 3,
                            Capacity = 150,
                            Description = "Farewell party for a friend",
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009),
                            EventName = "Farewell",
                            Location = "Voi"
                        });
                });

            modelBuilder.Entity("AttendeeEvent", b =>
                {
                    b.HasOne("eventsApi.Models.Attendee", null)
                        .WithMany()
                        .HasForeignKey("AttendeesAttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eventsApi.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
