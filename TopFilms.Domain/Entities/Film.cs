using System.ComponentModel.DataAnnotations;

namespace TopFilms.Domain.Entities
{
    public class Film
    {
        public int Film_id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? Release_Year { get; set; }
        public string? Director { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? Genre { get; set; }
        public string? Poster_Url { get; set; }
        public decimal? Rating { get; set; }

    }
}
