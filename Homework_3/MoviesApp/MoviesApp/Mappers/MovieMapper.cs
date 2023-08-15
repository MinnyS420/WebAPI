using MoviesApp.DTOs;
using MoviesApp.Models;

namespace MoviesApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDTO MapToMovieDTO(this Movie movie)
        {
            return new MovieDTO
            {
                title = movie.title,
                description = movie.description,
                genre = movie.genre,
                year = movie.year
            };
        }
    }
}
