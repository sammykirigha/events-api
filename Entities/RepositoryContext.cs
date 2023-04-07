using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().HasData(
                        new Event
                        {
                            EventId = 1,
                            EventName = "Wedding",
                            EventDate = new DateTime(2023 - 04 - 08),
                            Description = "A Friend wedding",
                            Location = "Nyeri",
                            Capacity = 100
                        },
                       new Event
                       {
                           EventId = 2,
                           EventName = "Birthday",
                           EventDate = new DateTime(2023 - 04 - 12),
                           Description = "Friend birthday party",
                           Location = "Nairobi",
                           Capacity = 50
                       },
                       new Event
                       {
                           EventId = 3,
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
                    AttendeeId = 1,
                    Email = "sammy@gmail.com",
                    Phone = "098767564",
                    FirstName = "Samuel",
                    LastName = "Kirigha",
                    Speaker = "Yes",
                },
                new Attendee
                {
                    AttendeeId = 2,
                    Email = "dorcis@gmail.com",
                    Phone = "098767564",
                    FirstName = "Dorcis",
                    LastName = "Kirigha",
                    Speaker = "No",
                },
                new Attendee
                {
                    AttendeeId = 3,
                    Email = "john@gmail.com",
                    Phone = "098767564",
                    FirstName = "John",
                    LastName = "Katua",
                    Speaker = "No",
                },
                new Attendee
                {
                    AttendeeId = 4,
                    Email = "flora@gmail.com",
                    Phone = "098767564",
                    FirstName = "Flora",
                    LastName = "Kirigha",
                    Speaker = "Yes",
                },
                new Attendee
                {
                    AttendeeId = 5,
                    Email = "synthia@gmail.com",
                    Phone = "098767564",
                    FirstName = "Synthia",
                    LastName = "Sau",
                    Speaker = "No",
                }
                );

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AttendeeEvent").HasData(
                new { AttendeesAttendeeId = 1, EventsEventId = 1 },
                new { AttendeesAttendeeId = 2, EventsEventId = 1 },
                new { AttendeesAttendeeId = 3, EventsEventId = 1 },
                new { AttendeesAttendeeId = 4, EventsEventId = 2 },
                new { AttendeesAttendeeId = 5, EventsEventId = 2 },
                new { AttendeesAttendeeId = 2, EventsEventId = 2 },
                new { AttendeesAttendeeId = 5, EventsEventId = 3 },
                new { AttendeesAttendeeId = 1, EventsEventId = 3 },
                new { AttendeesAttendeeId = 3, EventsEventId = 3 }
 );
        }
    }
}