using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Models;

namespace eventsApi.Contracts
{
    public interface IAttendeeEventRepository : IRepositoryBase<AttendeeEvent>
    {
        Task<IEnumerable<AttendeeEvent>> GetAllAttendeesEvents();
        void CreateAttendeeEvent(AttendeeEvent attendeeevent);
    }
}