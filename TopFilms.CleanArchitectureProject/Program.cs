using System.Buffers.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TopFilms.Application.Interfaces;
using TopFilms.Infrastructure.Persistence;
using TopFilms.Infrastructure.Repositories;
using TopFilms.Infrastructure.Services;
namespace TopFilms.CleanArchitectureProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FilmContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IFilmRepository, FilmRepositorie>();
            builder.Services.AddHttpClient<IFinderService, FinderService>(client =>
            {
                
                var baseUrl = builder.Configuration["OmdbApi:BaseUrl"];
                if (!string.IsNullOrEmpty(baseUrl))
                {
                    client.BaseAddress = new Uri(baseUrl);
                }
            });
            builder.Services.AddScoped<IFilmManager,FilmManagerService>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();

            app.MapControllerRoute(name: "default",pattern: "{controller=Film}/{action=Index}/{id?}").WithStaticAssets();

            app.Run();
        }
    }
}
