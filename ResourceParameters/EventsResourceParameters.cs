namespace eventsApi.ResourceParameters
{
    public class EventsResourceParameters: ResourceParameters
    {
        public string? EventName {get; set;}
        public string OrderBy {get; set;} = "EventName";
    }
}