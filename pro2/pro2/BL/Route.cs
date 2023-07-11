using Microsoft.AspNetCore.SignalR;
using pro2.Models;
using pro2.SignalR;

namespace pro2.BL
{
    public class Route
    {
        public Graph Landings { get; } = new Graph();
        public Graph Departures { get; } = new Graph();

        public Route(IHubContext<AirportHub> hub)//האב מאפשר לדבר עם הסינגל אר וליצור תקשורת לקליינט
        {
            Station st0 = new Station(0, hub);
            Station st1 = new Station(1, hub);
            Station st2 = new Station(2, hub);
            Station st3 = new Station(3, hub);
            Station st4 = new Station(4, hub);
            Station st5 = new Station(5, hub);
            Station st6 = new Station(6, hub);
            Station st7 = new Station(7, hub);
            Station st8 = new Station(8, hub);
            Station st9 = new Station(9, hub);
            Station st101 = new Station(101, hub);

            Landings.FirstStation = st0;
            Departures.FirstStation = st101;

            Landings.AddStation(st0);
            Landings.AddStation(st1);
            Landings.AddStation(st2);
            Landings.AddStation(st3);
            Landings.AddStation(st4);
            Landings.AddStation(st5);
            Landings.AddStation(st6);
            Landings.AddStation(st7);

            Landings.ConnectStations(st0, st1);
            Landings.ConnectStations(st1, st2);
            Landings.ConnectStations(st2, st3);
            Landings.ConnectStations(st3, st4);
            Landings.ConnectStations(st4, st5);
            Landings.ConnectStations(st5, st6);
            Landings.ConnectStations(st5, st7);

            Departures.AddStation(st101);
            Departures.AddStation(st7);
            Departures.AddStation(st8);
            Departures.AddStation(st4);
            Departures.AddStation(st9);

            Departures.ConnectStations(st101, st7);
            Departures.ConnectStations(st7, st8);
            Departures.ConnectStations(st8, st4);
            Departures.ConnectStations(st4, st9);

        }
    }
}

