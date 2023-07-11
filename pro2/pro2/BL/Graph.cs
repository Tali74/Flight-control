using pro2.Models;

namespace pro2.BL
{
    public class Graph//זה מבנה הנתונים
    {
        public Station? FirstStation { get; set; }

        Dictionary<Station, List<Station>> _dictionary = new();// זה השידנרי שלנו- קי סטיישן והוליו זה מי מקושר לתחנה הזאת

        public void AddStation(Station station) => _dictionary.Add(station, new List<Station>());

        public void ConnectStations(Station from, Station to) => _dictionary[from].Add(to);

        public List<Station> GetNextStations(Station from) => _dictionary[from];
    }
}
