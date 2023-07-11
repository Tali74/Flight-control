using Microsoft.AspNetCore.Mvc;
using pro2.BL;
using pro2.DB;
using pro2.Models;

namespace pro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase//הכל מתחיל בקונטרולקר והוא האינטרפייס שלנו לכל הדברים החוצה לאינטרנט
    {
        private readonly IAirportLogic airportLogic;
        private readonly BL.Route route;
        private readonly IRepository<FlightDB> repository;

        public AirportController(IAirportLogic airportLogic, BL.Route route, IRepository<FlightDB> repository)
        {
            this.airportLogic = airportLogic;
            this.route = route;
            this.repository = repository;
        }
        [HttpGet("FlightHistory")]// מציג ליסט של היסטוריה של הטיסות
        public IEnumerable<FlightDB> FlightHistory()
        {
            return repository.GetLastTen();
        }

        [HttpGet("Start")]
        public string Start()
        {
            return airportLogic.Start();
        }

        [HttpGet("AddLanding/{flight}")]// טיסות נוחתות וממריאות הסימולטור מפעיל אותם
        public IActionResult AddLanding(int flight)
        {
            if (airportLogic.ActiveFlights.Count > 8)//אם יש לי יותר מ8 מטוסים 
            {
                return BadRequest();//להחזיר באד ריקווסט לסימולטור
            }
            airportLogic.AddFlight(flight, route.Landings, "Landing");// אין אוויט כי לא נחזיק את הסימולטור עד שהטיסה תיגמר
            return Ok();//סטטוס קוד 200 שהכל בסדר
        }

        [HttpGet("AddDeparture/{flight}")]
        public IActionResult AddDeparture(int flight)
        {
            if (airportLogic.ActiveFlights.Count > 8)
            {
                return BadRequest();
            }
            airportLogic.AddFlight(flight, route.Departures, "Departure");
            return Ok();
        }

        [HttpGet("Status")]
        public AirportStatus GetStatus()
        {
            return airportLogic.GetStatus();
        }
    }
}
