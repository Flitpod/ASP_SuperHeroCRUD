using M3_SuperHeroCRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace M3_SuperHeroCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ISuperHeroRepository,SuperHeroRepository>();
            builder.Services.AddDbContext<SuperHeroDbContext>(options =>
            {
                string conn = "Server=(localdb)\\mssqllocaldb;Database=SuperHeroDb;Trusted_Connection=True;MultipleActiveResultSets=True";
                options
                    .UseSqlServer(conn);
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
