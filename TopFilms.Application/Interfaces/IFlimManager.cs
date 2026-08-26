using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopFilms.Domain.Entities;
namespace TopFilms.Application.Interfaces
{
    public interface IFilmManager
    {
        public Task<Film?> ImportFilmFromApiAsync(string title);
        public Task<IEnumerable<Film>> GetAllFilmsFromRepoAsync();
        public Task DeleteMovie(int id);
    }
}
