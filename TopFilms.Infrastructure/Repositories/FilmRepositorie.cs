using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopFilms.Domain.Entities;
using System.Threading.Tasks;
using TopFilms.Application.Interfaces;

namespace TopFilms.Infrastructure.Repositories
{
    public class FilmRepositorie:IFilmRepository
    {
        private readonly FilmContext _context;
        public FilmRepositorie(FilmContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Film>> GetAllFilmsAsync()
        {
            return await _context.Films.ToListAsync();
        }
    }
}
