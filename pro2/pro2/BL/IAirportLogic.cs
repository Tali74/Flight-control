using pro2.Models;

namespace pro2.BL
{
    public interface IAirportLogic
    {
        List<Flight> ActiveFlights { get; set; }
        Task AddFlight(int flight, Graph graph, string State);
        string Start();
        AirportStatus GetStatus();
    }
}
