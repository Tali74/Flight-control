namespace pro2.ModelsDTO
{
    public class StationUI
    {
        public int stationId { get; set; }
        public FlightUI flight { get; set; }

        public StationUI(int stationId, FlightUI flightUI)
        {
            this.stationId = stationId;
            flight = flightUI;
        }
    }
}
