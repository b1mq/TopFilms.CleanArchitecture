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
        public Task<Film> GetNewFilmAsync(string title)
        {
            var requesturl = $"?apikey={_ApiKey}&t={Uri.EscapeDataString(title)}";
            var response = _httpClient.GetFromJsonAsync<Film>(requesturl);
        }

    }
}
