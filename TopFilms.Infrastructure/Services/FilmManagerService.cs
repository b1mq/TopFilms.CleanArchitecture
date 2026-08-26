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
            var film = await _finderService.GetNewFilmAsync(title);
            if (film != null  &&  film.Title != "Not found")
            {
               await _filmRepository.SaveNewFilmAsync(film);
               return film;
            }
            return null;
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
