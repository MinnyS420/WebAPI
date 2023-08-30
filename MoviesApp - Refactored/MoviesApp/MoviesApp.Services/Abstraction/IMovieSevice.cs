using MoviesApp.Domain;
using MoviesApp.Domain.Enums;
using MoviesApp.DTOs;

namespace MoviesApp.Services.Abstraction
{
    public interface IMovieSevice
    {
        List<MovieDTO> GetAllMovies();
        MovieDTO GetById(int id);
        List<string> GetTitlesFromMovies(List<Movie> movies);
        List<MovieDTO> GetMoviesByGenreAndYear (Genre? genre, int? year);
        void AddMovie(MovieDTO addMovieDto);
        void UpdateMovie(UpdateMovieDTO updateMovieDto);
        void DeleteMovie(int id);
    }
}
