using Microsoft.EntityFrameworkCore;
using pro2.BL;
using pro2.DB;
using pro2.SignalR;

namespace pro2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IAirportLogic, AirportLogic>();
            builder.Services.AddSingleton<BL.Route>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSignalR();

            builder.Services.AddCors(o =>
            o.AddDefaultPolicy(o =>
            o.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")));

            builder.Services.AddDbContext<AirportContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("main")), ServiceLifetime.Singleton);
            builder.Services.AddSingleton<IRepository<FlightDB>, FightHistoryRepo>();
            var app = builder.Build();

            app.UseCors();
            app.UseAuthentication();


            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<AirportHub>("/airport");
            app.Run();
        }
    }
}