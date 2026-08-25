using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopFilms.Domain.Entities;

namespace TopFilms.Application.Interfaces
{
    public interface IFilmRepository
    {
        public Task<List<Film>> GetAllFims();
        public Task<Film> GetFilmById(int filmId);
        public Task SaveNewFilm(Film film);
        public Task DeleteFilm(int filmId);
        public Task UpdateFilm(Film film);
    }
}
