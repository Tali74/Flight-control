using System.ComponentModel.DataAnnotations;

namespace pro2.DB
{
    public class FlightDB
    {
        [Key]
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string State { get; set; }

        public FlightDB(int flightId, DateTime enterTime, string state)
        {
            FlightId = flightId;
            EnterTime = enterTime;
            State = state;
        }
    }
}
