using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Contracts
{
    public interface IAttendeeRepository : IRepositoryBase<Attendee>
    {
        Task<IEnumerable<Attendee>> GetAllAttendeesAsync();
        Task<Attendee> GetAttendeeByIdAsync(Guid attendeeId);
        Task<Attendee> GetAttendeeWithDetailsAsync(Guid attendeeId);
        void CreateAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
    }
}