using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopFilms.Domain.Entities;
namespace TopFilms.Application.Interfaces
{
    public interface IFinderService
    {
        public Task<Film> GetNewFilmAsync(string title);
    }
}
