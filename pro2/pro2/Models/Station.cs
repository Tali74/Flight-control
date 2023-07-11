using Microsoft.AspNetCore.SignalR;
using pro2.ModelsDTO;
using pro2.SignalR;
using System.Text.Json;

namespace pro2.Models
{
    public class Station
    {
        public int Id { get; set; }
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);//אובייקט סינכרון
        private Flight? _occupiedFlight;
        private readonly IHubContext<AirportHub> hub;// מקבלים אותו מדיפנדנסי אינג'קשיין, תקשורת לבחוץ עם סינגל אר

        public Station(int id, IHubContext<AirportHub> hub)
        {
            Id = id;
            this.hub = hub;
        }

        public async Task<Station?> EnterStation(Flight flight, CancellationTokenSource cts)//מטוס אחד כאילו מתפצל לכמה מטוסים ומנסה להכינס לתחנות
        {
            try
            {
                await _semaphore.WaitAsync(cts.Token);//המטוס נכנס לתחנה ותופס אותה
                cts.Cancel();//במקר של מטוס שנכנס ל6 או ל7 אז השני מתבטל
                _occupiedFlight = flight;
                await SendToClient(flight.Id);//שולחים לריאקט
                Console.WriteLine($"Flight {flight.Id} is Enter Station {this.Id}");
                return this;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }

        private async Task SendToClient(int flightId)
        {
            var s = new StationUI(Id, new FlightUI(flightId));
            var json = JsonSerializer.Serialize(s);
            await hub.Clients.All.SendAsync("RecieveStation", json);
        }

        public async void ExitStation()
        {
            Console.WriteLine($"Flightt {_occupiedFlight?.Id} is Exit Station {this.Id}");
            _occupiedFlight = null;// מרוקנים את התחנה
            await SendToClient(0);//0 זה שהמטוס לא שם
            _semaphore.Release();//מטוס יוצא מהתחנה
        }
    }
}
