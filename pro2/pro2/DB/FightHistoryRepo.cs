namespace pro2.DB
{
    public class FightHistoryRepo : IRepository<FlightDB>
    {
        private readonly AirportContext context;//מקבלים את הקונטקסט

        public FightHistoryRepo(AirportContext context)
        {
            this.context = context;
        }
        public async Task Add(FlightDB entity)//מקבלים אובייקט מוסיפים לפלייט ושומרים
        {
            context.Flights.Add(entity);
           await Save();
        }

        public FlightDB? Get(int id)
        {
            return context.Flights.SingleOrDefault(c => c.Id == id);// תחזיר לי אחד בודד
        }


        public IEnumerable<FlightDB> GetLastTen()
        {
            return context.Flights.OrderByDescending(x => x.EnterTime).Take(10);//מסדרים את טבלה בסדר יורד ומחזירים את 10 ראשונים בזמנים
        }
        async Task<int> Save()//אסיכרוני כדי שהוא יעשה את עבודה ללא תלות
        {
            return await context.SaveChangesAsync();
        }
    }
}
