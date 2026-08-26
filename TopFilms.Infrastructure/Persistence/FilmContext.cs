using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopFilms.Domain.Entities;
namespace TopFilms.Infrastructure.Persistence
{
    public class FilmContext:DbContext
    {
        public DbSet<Film> films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.Film_id);
            });
        }
    }
}
