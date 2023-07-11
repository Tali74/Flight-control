using static System.Net.WebRequestMethods;

namespace Simulator
{
    public class Simulator
    {
        HttpClient httpClient = new HttpClient();
        int count1 = 1;//קשור להמראות
        int count101 = 101;//קשור לנחיתות
        string url = "http://localhost:5001/api/Airport/";
        public async Task Start()
        {
            while (true)//לולאה שמריצה מספרים רנדומלים ולפי מה שיוצא הוא יוצר מטוס ממריא או נוחת
            {
                await Task.Delay(3000);//הלולאה מופעלת כל 3 שניות
                if (Environment.TickCount % 2 == 0)// זה הפעלת הרנדומליות פה יש רק 0 או 1, אם יצא 0 אז זה ממריא אם 1 אז נוחת
                {
                    var res = await httpClient.GetAsync(url+"AddLanding/" + count1);
                    while (!res.IsSuccessStatusCode)// אם זה לא מצליח בגלל שיש יותר מ8 מטובים אז יש 3 שניות דיליי ואז הוא מנסה שובת זה הבאד ריקווסט מהקונטרולר
                    {
                        await Task.Delay(3000);
                        res = await httpClient.GetAsync(url + "AddLanding/" + count1);
                    }
                    count1++;//עוברים למטוס הבא
                }
                else
                {
                    var res = await httpClient.GetAsync(url + "AddDeparture/" + count101);
                    while (!res.IsSuccessStatusCode)
                    {
                        await Task.Delay(3000);
                        res = await httpClient.GetAsync(url + "AddDeparture/" + count101);
                    }
                    count101++;
                }
            }
        }
    }
}
