using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eventsApi.Contracts
{
    public interface IRepositoryWrapper
    {
        IEventRepository Event { get; }
        IAttendeeRepository Attendee { get; }
        IAttendeeEventRepository AttendeeEvent {get;}
        Task SaveAsync();
    }
}