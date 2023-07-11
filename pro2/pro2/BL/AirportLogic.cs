using pro2.DB;
using pro2.Models;

namespace pro2.BL
{
    public class AirportLogic : IAirportLogic
    {
        bool _isStarted = false;
        private readonly IRepository<FlightDB> repo;//מעבירים ריפוזיטורי בשבשיל שנוכל לדבר עם הדטא בייס

        public List<Flight> ActiveFlights { get; set; } = new List<Flight>();//כל הטיסות שיש לנו ברגע הזה על הלוח

        public AirportLogic(IRepository<FlightDB> repo)
        {
            this.repo = repo;
        }
        public async Task AddFlight(int flightId, Graph graph, string State)//לוגיט מייצר טיסה
        {

            if (!_isStarted)
            {
                Console.WriteLine("Airport Isn't Active");
                return;
            }
            var flight = new Flight(flightId);//אם התוכנה מאותחלת מוסיפים מטוס חדש עם השם שלו
            ActiveFlights.Add(flight);//מוסיפים את הטיסה לרשימת הטיסות הפעילות

            Console.WriteLine($"Flight {flightId} Added");
            var flightDB = new FlightDB(flight.Id, DateTime.Now, State);
            await flight.Run(graph, graph.FirstStation!);// הראן נותן את המסלול את התחנה הראשונה ואומר למטוס להמשיך לרוץ עצמאית ומתפנה לדברים אחרים
            flightDB.ExitTime = DateTime.Now;//שולחים את המידע לדטא בייס
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Flight {flight.Id} Has Reached Safetly.");
            Console.ForegroundColor = ConsoleColor.White;

            ActiveFlights.Remove(flight);//מוציאים מהליסט
           await repo.Add(flightDB);//מוסיפים לדטא בייס
        }

        public AirportStatus GetStatus()
        {
            return new AirportStatus
            {
                Status = _isStarted ? "Started" : "NotStarted",
                Flights = ActiveFlights.Select(f => f.ToString()).ToList(),
            };
        }

        public string Start()
        {
            if (_isStarted)
                return "All ready started";

            _isStarted = true;
            return "started";
        }
    }
}
