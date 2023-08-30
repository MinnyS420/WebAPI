using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain;

namespace MoviesApp.DataAccess
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Title = "Foo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Action,
                    Year = 2014,
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    Title = "Boo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Thriller,
                    Year = 2015,
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 3,
                    Title = "Hoo",
                    Description = "Bar",
                    Genre = Domain.Enums.Genre.Comedy,
                    Year = 2016,
                });
        }
    }
}
