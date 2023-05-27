using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eventsApi.Contracts;
using eventsApi.Entities;

namespace eventsApi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPropertyMappingService _propertyMappingService;
        private IEventRepository _event;
        private IAttendeeRepository _attendee;
        private IAttendeeEventRepository _attendeeevent;

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repoContext, (EventPropertyMappingService)_propertyMappingService);
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
                    _attendee = new AttendeeRepository(_repoContext, (AttendeePropertyMappingService)_propertyMappingService);
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

        public RepositoryWrapper(RepositoryContext repositoryContext, IPropertyMappingService propertyMappingService)
        {
            _repoContext = repositoryContext;
            _propertyMappingService = propertyMappingService;
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}