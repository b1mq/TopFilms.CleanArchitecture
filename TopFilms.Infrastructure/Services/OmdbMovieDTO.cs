using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TopFilms.Infrastructure.Services
{
    public class OmdbMovieDTO
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; } 

        [JsonPropertyName("Plot")]
        public string? Plot { get; set; } 

        [JsonPropertyName("Year")]
        public string? Year { get; set; } 

        [JsonPropertyName("Director")]
        public string? Director { get; set; } 

        [JsonPropertyName("Language")]
        public string? Language { get; set; } 

        [JsonPropertyName("Country")]
        public string? Country { get; set; } 

        [JsonPropertyName("Genre")]
        public string? Genre { get; set; }

        [JsonPropertyName("Poster")]
        public string? Poster { get; set; } 

        [JsonPropertyName("imdbRating")]
        public string? ImdbRating { get; set; }
    }
}
