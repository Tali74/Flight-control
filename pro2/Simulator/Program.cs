namespace Simulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           

            builder.Services.AddControllers();
            builder.Services.AddSingleton<Simulator>();

            var app = builder.Build();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}