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
        public Task<IEnumerable<Film>> GetAllFilmsAsync();
        public Task<Film> GetFilmByIdAsync(int filmId);
        public Task SaveNewFilmAsync(Film film);
        public Task DeleteFilmAsync(int filmId);
        public Task UpdateFilmAsync(Film film);
        public Task<Film?> GetFilmByTitle (string title);
    }
}
