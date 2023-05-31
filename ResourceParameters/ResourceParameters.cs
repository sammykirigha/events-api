namespace eventsApi.ResourceParameters
{
    public class ResourceParameters
    {
        public string? SearchQuery { get; set; }
        const int maxPageSize = 20;
        public int PageNumber {get; set;} = 1;
        public int _pageSize {get; set;} = 10;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}