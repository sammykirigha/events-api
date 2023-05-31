
using eventsApi.Contracts;
using eventsApi.Entities;
using eventsApi.MappingServices;

namespace eventsApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        AttendeePropertyMappingService attendeePropertyMappingService;
        IEventPropertyMappingService _eventpropertyMappingService;
        private IEventRepository _event;
        private IAttendeeRepository _attendee;
        private IAttendeeEventRepository _attendeeevent;

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repoContext, _eventpropertyMappingService);
                }
                return _event;
            }
        }
        public IAttendeeRepository Attendee
        {
            get
            {
                if (_attendee == null)
                {
                    _attendee = new AttendeeRepository(_repoContext);
                }
                return _attendee;
            }
        }
        public IAttendeeEventRepository AttendeeEvent
        {
            get
            {
                if (_attendeeevent == null)
                {
                    _attendeeevent = new AttendeeEventRepository(_repoContext);
                }
                return _attendeeevent;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext, IEventPropertyMappingService eventpropertyMappingService)
        {
            _repoContext = repositoryContext;
            _eventpropertyMappingService = eventpropertyMappingService;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}