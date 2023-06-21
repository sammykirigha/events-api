namespace eventsApi.ResourceParameters
{
    public class AttendeesResourceParameters : ResourceParameters
    {
        public string? Name { get; set; }
        public string OrderBy { get; set; } = "Name";
    }
}