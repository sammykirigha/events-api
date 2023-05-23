namespace eventsApi.ResourceParameters
{
    public class EventsResourceParameters
    {
        const int maxPageSize = 20;
        public string? EventName {get; set;}
        public string? SearchQuery {get; set;}

        public int PageNumber {get; set;} = 1;

        public int _pageSize {get; set;} = 10;

        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}