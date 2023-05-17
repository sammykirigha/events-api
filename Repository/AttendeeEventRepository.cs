using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using eventsApi.Entities;
using eventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Repository
{
    public class AttendeeEventRepository : RepositoryBase<AttendeeEvent>, IAttendeeEventRepository
    {
        public AttendeeEventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<IEnumerable<AttendeeEvent>> GetAllAttendeesEvents()
        {
            var results = await FindAll().ToListAsync();
            return results;
        }

        public void CreateAttendeeEvent(AttendeeEvent attendeeevent)
        {
           Create(attendeeevent);
        }
    }
}