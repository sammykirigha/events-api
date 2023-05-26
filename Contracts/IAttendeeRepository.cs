using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.ResourceParameters;
using eventsApi.Models;
using eventsApi.Helpers;

namespace eventsApi.Contracts
{
    public interface IAttendeeRepository : IRepositoryBase<Attendee>
    {
        Task<IEnumerable<Attendee>> GetAllAttendeesAsync();
        Task<PageList<Attendee>> GetAllAttendeesAsync(AttendeesResourceParameters attendeesResourceParameters);
        Task<Attendee> GetAttendeeByIdAsync(Guid attendeeId);
        Task<Attendee> GetAttendeeByEmailAsync(string email);
        void CreateAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
    }
}