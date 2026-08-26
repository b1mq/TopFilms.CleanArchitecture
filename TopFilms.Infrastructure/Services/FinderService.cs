using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TopFilms.Application.Interfaces;
using TopFilms.Domain.Entities;

namespace TopFilms.Infrastructure.Services
{
    public class FinderService:IFinderService
    {
        private readonly string? _ApiKey;
        private readonly HttpClient _httpClient;
        public FinderService(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            _ApiKey = configuration["OmdbApi:ApiKey"];
        }
        public async Task<Film> GetNewFilmAsync(string title)
        {
            var requestUri = $"?apikey={_ApiKey}&t={Uri.EscapeDataString(title)}";
            var movieDto = await _httpClient.GetFromJsonAsync<OmdbMovieDTO>(requestUri);
            if (movieDto == null || string.IsNullOrEmpty(title))
            {
                return new Film { Title = "Not found" };
            }
            var film = new Film
            {
                Title = movieDto.Title,
                Description = movieDto.Plot,
                Director = movieDto.Director,
                Language = movieDto.Language,
                Country = movieDto.Country,
                Genre = movieDto.Genre,
                Poster_Url = movieDto.Poster
            };
            if(int.TryParse(movieDto.Year, out int parsedYear))
            {
                film.Release_Year = parsedYear;
            }
            if(decimal.TryParse(movieDto.ImdbRating,out  decimal parsedRating)) {
                film.Rating = parsedRating;
            }
            return film;
        }

    }
}
