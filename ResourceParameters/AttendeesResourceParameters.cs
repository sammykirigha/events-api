namespace eventsApi.ResourceParameters
{
    public class AttendeesResourceParameters : ResourceParameters
    {
        public string? AttendeeName { get; set; }
        public string OrderBy { get; set; } = "Name";
    }
}