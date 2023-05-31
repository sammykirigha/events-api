using eventsApi.Repository;

namespace eventsApi.Contracts;
public interface IEventPropertyMappingService
{
    public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
}