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
            return await FindAll().OrderBy(att => att.AttendeeId).ToListAsync();
        }

        public async Task<Attendee> GetAttendeeByIdAsync(Guid attendeeId)
        {
            return await FindByCondition(attendee => attendee.AttendeeId.Equals(attendeeId)).FirstOrDefaultAsync();
        }

        public async Task<Attendee> GetAttendeeWithDetailsAsync(Guid attendeeId)
        {
            return await FindByCondition(attendee => attendee.AttendeeId.Equals(attendeeId)).Include(ev => ev.Event).FirstOrDefaultAsync();
        }

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