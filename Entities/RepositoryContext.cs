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

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = 1,
                EventName = "Wedding",
                EventDate = new DateTime(2023 - 04 - 08),
                Description = "A Friend wedding",
                Location = "Nyeri",
                Capacity = 100
            });

            modelBuilder.Entity<Attendee>().HasData(new Attendee
            {
                AttendeeId = 1,
                Email = "sammy@gmail.com",
                Phone = "098767564",
                FirstName = "Samuel",
                LastName = "Kirigha",
                Speaker = "Yes",
                EventId = 1
            });
        }
    }
}