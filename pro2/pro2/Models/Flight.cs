using pro2.BL;

namespace pro2.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Station? CurrentStation { get; set; }

        public Flight(int flightId)
        {
            Id = flightId;
        }

        public async Task Run(Graph route, Station firstStation)//קבלת מסלול התחלתי
        {
            CurrentStation = firstStation;//אתחול התחנה הנוכחית במסלול
            await Task.Run(async () =>
            {
                Station? nextStation;
                do
                {
                    var nextStations = route.GetNextStations(CurrentStation);//בשביל לקדם את המטוס שמים את התחנה הנוכחית בהבאה
                    if (nextStations.Count == 0)//מוודאים שהתחנות הבאות פנויות ואם לא
                    {
                        CurrentStation.ExitStation();//מרוקנים את התחנה מהמטוסים
                        CurrentStation = null;
                        Console.WriteLine("Flight " + Id + " finish");
                        return;
                    }
                    nextStation = await GetFirstAvailable(nextStations);// אם היו כמה תחנות מקושרות אז מחזיר את האחת שאנחנו רוצים ומתאים
                    if (nextStation != null)
                    {
                        await MoveToNextStation(nextStation);
                    }
                } while (nextStation != null);//אם אין עוד תחנות אז מסיימים את התוכנית
            });
        }
        private async Task<Station?> GetFirstAvailable(List<Station> nextStations)
        {
            CancellationTokenSource _cts = new CancellationTokenSource();//מנהל את ביטולים
            if (nextStations.Count == 0)
            {
                return null;
            }
            List<Task<Station?>>? enterStationTasks = nextStations // מנסה להיכנס לכל התחנות
                .Select(async s => await s.EnterStation(this, _cts))// אחת מצליחה וכל השאר נכשלות
                .ToList();

            var enteredStation = await Task.WhenAny(enterStationTasks);//ברגע שאחד מצליח אנחנו מקדים את האנטר סטיישן שלנו
            return await enteredStation;//מחזיר את התחנה
        }

        private async Task MoveToNextStation(Station nextStation)
        {

            CurrentStation?.ExitStation();//יוצא צהתחנה קודמת

            CurrentStation = nextStation;//מגדיר את תחנ שעברו אליה כתחנה העכשוית

            await Task.Delay(3000);//מחכים 3 שניות לפני שממשיכים הלאה
            Console.WriteLine($"flight '{Id}' is moving to nextStation {nextStation.Id}");
        }

        public override string ToString()
        {
            return $"Flight {Id} is in  {CurrentStation}";
        }
    }
}
