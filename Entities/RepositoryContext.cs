using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Entities.Models;
using eventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventAttendee>().HasKey(ea => new { ea.AttendeesAttendeeId, ea.EventsEventId });

            // modelBuilder.Entity<Event>().HasMany(e => e.Attendees).WithMany(e => e.Events).UsingEntity<Dictionary<string, object>>("EventAttendees", j => j.HasOne<Attendee>().WithMany().HasForeignKey("AttendeesAttendeeId"), j => j.HasOne<Event>().WithMany().HasForeignKey("EventsEventId"));


            modelBuilder.Entity<EventAttendee>().HasOne<Attendee>(x => x.Attendee).WithMany(y => y.EventAttendees).HasForeignKey(x => x.AttendeesAttendeeId);
            modelBuilder.Entity<EventAttendee>().HasOne<Event>(x => x.Event).WithMany(y => y.EventAttendees).HasForeignKey(x => x.EventsEventId);

            modelBuilder.Entity<EventAttendee>().ToTable("EventAttendees");

            modelBuilder.Entity<Event>().HasData(
                        new Event
                        {
                            EventId = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            EventName = "Wedding",
                            EventDate = new DateTime(2023 - 04 - 08),
                            Description = "A Friend wedding",
                            Location = "Nyeri",
                            Capacity = 100
                        },
                       new Event
                       {
                           EventId = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                           EventName = "Birthday",
                           EventDate = new DateTime(2023 - 04 - 12),
                           Description = "Friend birthday party",
                           Location = "Nairobi",
                           Capacity = 50
                       },
                       new Event
                       {
                           EventId = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                           EventName = "Farewell",
                           EventDate = new DateTime(2023 - 04 - 10),
                           Description = "Farewell party for a friend",
                           Location = "Voi",
                           Capacity = 150
                       }
            );

            modelBuilder.Entity<Attendee>().HasData(
                new Attendee
                {
                    AttendeeId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Email = "sammy@gmail.com",
                    Phone = "098767564",
                    FirstName = "Samuel",
                    LastName = "Kirigha",
                    Speaker = "Yes",
                },
                new Attendee
                {
                    AttendeeId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Email = "dorcis@gmail.com",
                    Phone = "098767564",
                    FirstName = "Dorcis",
                    LastName = "Kirigha",
                    Speaker = "No",
                },
                new Attendee
                {
                    AttendeeId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Email = "john@gmail.com",
                    Phone = "098767564",
                    FirstName = "John",
                    LastName = "Katua",
                    Speaker = "No",
                },
                new Attendee
                {
                    AttendeeId = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Email = "flora@gmail.com",
                    Phone = "098767564",
                    FirstName = "Flora",
                    LastName = "Kirigha",
                    Speaker = "Yes",
                },
                new Attendee
                {
                    AttendeeId = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Email = "synthia@gmail.com",
                    Phone = "098767564",
                    FirstName = "Synthia",
                    LastName = "Sau",
                    Speaker = "No",
                }
                );

            // modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AttendeeEventId").HasData(
            //     new { AttendeesAttendeeId = 1, EventsEventId = 1 },
            //     new { AttendeesAttendeeId = 2, EventsEventId = 1 },
            //     new { AttendeesAttendeeId = 3, EventsEventId = 1 },
            //     new { AttendeesAttendeeId = 4, EventsEventId = 2 },
            //     new { AttendeesAttendeeId = 5, EventsEventId = 2 },
            //     new { AttendeesAttendeeId = 2, EventsEventId = 2 },
            //     new { AttendeesAttendeeId = 5, EventsEventId = 3 },
            //     new { AttendeesAttendeeId = 1, EventsEventId = 3 },
            //     new { AttendeesAttendeeId = 3, EventsEventId = 3 }
            //  );

        }


        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<EventAttendee> AttendeeEvent { get; set; }


    }
}