using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopFilms.Application.Interfaces;
using TopFilms.Domain.Entities;
namespace TopFilms.Infrastructure.Services
{
    public class FilmManagerService: IFilmManager
    {
        private readonly IFinderService _finderService;
        private readonly IFilmRepository _filmRepository;
        public FilmManagerService(IFinderService finderService, IFilmRepository filmRepository)
        {
            _finderService = finderService;
            _filmRepository = filmRepository;
        }
        public async Task<Film?> ImportFilmFromApiAsync(string title)
        {
            // доделать логику проверки запроса в бд есть ли уже такой фильм добавить в репо метод получение по названию...

            var film = await _finderService.GetNewFilmAsync(title);
            if (film == null  ||  film.Title == "Not found")
            {
                return null;
            }
            var existFilmInDb = await _filmRepository.GetFilmByTitle(film.Title);
            if(existFilmInDb == null)
            {
                await _filmRepository.SaveNewFilmAsync(film);
                return film;

            }
            return existFilmInDb;
            
            
        }
        public async Task<IEnumerable<Film>> GetAllFilmsFromRepoAsync()
        {
            var films = await _filmRepository.GetAllFilmsAsync();
            return films;
        }
        public async Task DeleteMovie(int id)
        {
            await _filmRepository.DeleteFilmAsync(id);
        }
    }
}
