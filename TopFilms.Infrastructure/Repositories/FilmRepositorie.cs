using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopFilms.Domain.Entities;
using System.Threading.Tasks;
using TopFilms.Application.Interfaces;
using TopFilms.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return await _context.films.ToListAsync();
        }
        public async Task<Film> GetFilmByIdAsync(int id)
        {
            var filmToFind = await _context.films.FindAsync(id);
            if (filmToFind != null)
            {
                return filmToFind;
            }
            return new Film();
        }
        public async Task SaveNewFilmAsync(Film film)
        {
            await _context.AddAsync(film);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFilmAsync(int id)
        {
           
            var filmToDelete = await _context.films.FindAsync(id);
            if (filmToDelete != null)
            {
                _context.films.Remove(filmToDelete);
                await _context.SaveChangesAsync();
            }

        }
        public async Task UpdateFilmAsync(Film film)
        {
             _context.films.Update(film);
            await _context.SaveChangesAsync();
        }
        public async Task<Film?> GetFilmByTitle(string title)
        {
            var film = await _context.films.FirstOrDefaultAsync(f => f.Title == title);
            return film;
        }
    }
}
