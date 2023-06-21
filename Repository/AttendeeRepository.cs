using eventsApi.Contracts;
using eventsApi.DbContexts;
using eventsApi.Dtos;
using eventsApi.Helpers;
using eventsApi.MappingServices;
using eventsApi.Models;
using eventsApi.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace eventsApi.Repository
{
    public class AttendeeRepository : RepositoryBase<Attendee>, IAttendeeRepository
    {
        private readonly IPropertyMappingService _propertyMappingService;
        public AttendeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
         }

        public async Task<IEnumerable<Attendee>> GetAllAttendeesAsync()
        {
            var results = await FindAll().Include(a => a.Events).OrderBy(att => att.FirstName).ThenBy(att => att.LastName).ToListAsync();
            return results;
        }

        public async Task<Attendee> GetAttendeeByIdAsync(Guid id)
        {
            var result = await FindByCondition(attendee => attendee.Id.Equals(id)).FirstOrDefaultAsync();
            return result!;
        }
        public async Task<Attendee> GetAttendeeByEmailAsync(string email)
        {
            var result = await FindByCondition(attendee => attendee.Email.Equals(email)).FirstOrDefaultAsync();
            return result!;
        }


        public void CreateAttendee(Attendee attendee)
        {
            attendee.Id = Guid.NewGuid();

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

        public async Task<PageList<Attendee>> GetAllAttendeesAsync(AttendeesResourceParameters attendeesResourceParameters)
        {
            if (attendeesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(attendeesResourceParameters));
            }

            var collection = FindAll().Include(a => a.Events) as IQueryable<Attendee>;

            if (!String.IsNullOrWhiteSpace(attendeesResourceParameters.Name))
            {
                var attendeeName = attendeesResourceParameters?.Name.Trim().ToLower();
                collection = collection.Where(a => a.FirstName == attendeeName || a.LastName == attendeeName);
            }

            if (!String.IsNullOrWhiteSpace(attendeesResourceParameters?.SearchQuery))
            {
                var searchQuery = attendeesResourceParameters.SearchQuery.Trim().ToLower();
                collection = collection.Where(a => a.FirstName.Contains(searchQuery)
                    || a.LastName.Contains(searchQuery)
                    || a.Email.Contains(searchQuery)
                    );
            }

            // if (!string.IsNullOrWhiteSpace(attendeesResourceParameters.OrderBy))
            // {
            //     var attendeePropertyMappingDictionary = _propertyMappingService.GetPropertyMapping<AttendeeDto, Attendee>();

            //     collection = collection.ApplySort(attendeesResourceParameters.OrderBy, attendeePropertyMappingDictionary);
            // }


            return await PageList<Attendee>.CreateAsync(collection,
            attendeesResourceParameters.PageNumber,
            attendeesResourceParameters.PageSize
            );
        }
    }
}