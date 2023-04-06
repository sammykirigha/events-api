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
    public class AttendeeRepository : RepositoryBase<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public async Task<IEnumerable<Attendee>> GetAllAttendeesAsync()
        {
            var results = await FindAll().OrderBy(att => att.AttendeeId).ToListAsync();
            return results;
        }

        public async Task<Attendee> GetAttendeeByIdAsync(int attendeeId)
        {
            var result = await FindByCondition(attendee => attendee.AttendeeId.Equals(attendeeId)).FirstOrDefaultAsync();
            return result!;
        }

        // public async Task<Attendee> GetAttendeeWithDetailsAsync(int attendeeId)
        // {
        //     var results = await FindByCondition(attendee => attendee.AttendeeId.Equals(attendeeId)).Include(ev => ev.events).FirstOrDefaultAsync();
        //     return results!;
        // }

        public void CreateAttendee(Attendee attendee)
        {
            Create(attendee);
        }

        public void UpdateAttendee(Attendee attendee)
        {
            Update(attendee);
        }

        public void DeleteAttendee(Attendee attendee)
        {
            Delete(attendee);
        }
    }
}