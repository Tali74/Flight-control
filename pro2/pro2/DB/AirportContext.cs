using Microsoft.EntityFrameworkCore;

namespace pro2.DB
{
    public class AirportContext : DbContext
    {
        public DbSet <FlightDB> Flights { get; set; }
        public AirportContext(DbContextOptions<AirportContext> o) : base (o)//מקבל בקונסטרקטור מידע מהפרוגרם שורה 28 ואותו אנחנו מעבירים הלאה
        {
            
        }
    }
}
