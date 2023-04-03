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
        private IEventRepository _event;
        private IAttendeeRepository _attendee;

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repoContext);
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

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}