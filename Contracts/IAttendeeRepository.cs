using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Contracts
{
    public interface IAttendeeRepository : IRepositoryBase<Attendee>
    {
        Task<IList<Attendee>> GetAllAttendeesAsync();
        Task<Attendee> GetAttendeeByIdAsync(int attendeeId);
        Task<Attendee> GetAttendeeWithDetailsAsync(int attendeeId);
        void CreateAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void DeleteAttendee(Attendee attendee);
    }
}