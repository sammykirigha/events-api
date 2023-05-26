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
    [Migration("20230526083237_addedDateField")]
    partial class addedDateField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eventsApi.Models.Attendee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Attendees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "sammy@gmail.com",
                            FirstName = "Samuel",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "Yes"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "dorcis@gmail.com",
                            FirstName = "Dorcis",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "No"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "john@gmail.com",
                            FirstName = "John",
                            LastName = "Katua",
                            Phone = "098767564",
                            Speaker = "No"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "flora@gmail.com",
                            FirstName = "Flora",
                            LastName = "Kirigha",
                            Phone = "098767564",
                            Speaker = "Yes"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Email = "synthia@gmail.com",
                            FirstName = "Synthia",
                            LastName = "Sau",
                            Phone = "098767564",
                            Speaker = "No"
                        });
                });

            modelBuilder.Entity("eventsApi.Models.AttendeeEvent", b =>
                {
                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AttendeeId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("AttendeeEvents");
                });

            modelBuilder.Entity("eventsApi.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Capacity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EventDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Capacity = 100,
                            Description = "A Friend wedding",
                            EventDate = new DateTimeOffset(new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            EventName = "Wedding",
                            Location = "Nyeri"
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            Capacity = 50,
                            Description = "Friend birthday party",
                            EventDate = new DateTimeOffset(new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            EventName = "Birthday",
                            Location = "Nairobi"
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            Capacity = 150,
                            Description = "Farewell party for a friend",
                            EventDate = new DateTimeOffset(new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            EventName = "Farewell",
                            Location = "Voi"
                        });
                });

            modelBuilder.Entity("eventsApi.Models.AttendeeEvent", b =>
                {
                    b.HasOne("eventsApi.Models.Attendee", "Attendee")
                        .WithMany("AttendeeEvents")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eventsApi.Models.Event", "Event")
                        .WithMany("AttendeeEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("eventsApi.Models.Attendee", b =>
                {
                    b.Navigation("AttendeeEvents");
                });

            modelBuilder.Entity("eventsApi.Models.Event", b =>
                {
                    b.Navigation("AttendeeEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
