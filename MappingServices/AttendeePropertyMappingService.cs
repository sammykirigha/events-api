using eventsApi.Contracts;
using eventsApi.Models;
using eventsApi.Repository;

namespace eventsApi.MappingServices
{

    public class AttendeePropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _attendeePropertyMapping =
        new(StringComparer.OrdinalIgnoreCase)
        {
            {"Id", new(new[] {"Id"})},
            {"Name", new(new[] {"FirstName", "LastName"})},
            {"Email", new(new[] {"Email"})},
            {"Age", new(new[] {"DateOfBirth"}, true)}
        };

        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public AttendeePropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<Dtos.AttendeeDto, Attendee>(_attendeePropertyMapping));
        }


        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            //get matching mapping
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First().MappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance " + $"for <{typeof(TSource)}, {typeof(TDestination)}");
        }

    }
}