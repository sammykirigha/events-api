using eventsApi.Contracts;
using eventsApi.Dtos.eventsDto;
using eventsApi.Models;

namespace eventsApi.Repository
{

    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _eventPropertyMapping =
        new(StringComparer.OrdinalIgnoreCase)
        {
            {"Id", new(new[] {"Id"})},
            {"EventName", new(new[] {"EventName"})},
            {"EventDate", new(new[] {"EventDate"})},
            {"Location", new(new[] {"Location"})},
            {"Capacity", new(new[] {"Capacity"})},
        };

        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<EventDto, Event>(_eventPropertyMapping));
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