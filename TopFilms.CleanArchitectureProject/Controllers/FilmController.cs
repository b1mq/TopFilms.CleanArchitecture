using Microsoft.AspNetCore.Mvc;
using TopFilms.Application.Interfaces;

namespace TopFilms.WebUI.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmManager _filmManager;
        public FilmController(IFilmManager filmManager)
        {
            _filmManager = filmManager;
        }
        public async Task< IActionResult> Index()
        {
            var films = await _filmManager.GetAllFilmsFromRepoAsync();
            return View(films);
        }
        public async Task<IActionResult> GetNewFilm(string title)
        {
            var film = await _filmManager.ImportFilmFromApiAsync(title);
            return View(film);
        }
        public async Task<IActionResult> DeleteMovie(int id)
        {
            
        }
    }
}
