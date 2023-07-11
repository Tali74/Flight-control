namespace pro2.Models
{
    public class AirportStatus
    {
        public string? Status { get; set; }
        public List<string> Flights { get; set; } = new List<string>();
    }
}
