using Microsoft.AspNetCore.Mvc;
using MoviesApp.DTOs;
using MoviesApp.Mappers;
using MoviesApp.Models;
using MoviesApp.Models.Enums;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet] //https://localhost:[port]/api/Movies
        public IActionResult Get()  
        {
            try
            {
                List<Movie> movieDb = StaticDb.Movies;

                var mapToMovieDb = movieDb.Select(x => x.MapToMovieDTO()).ToList();

                return Ok(mapToMovieDb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }
        [HttpPost] //https://localhost:[port]/api/Movies
        public IActionResult AddNewMovie([FromBody] Movie newMovie)
        {
            if (newMovie == null)
            {
                return BadRequest("Invalid movie data!");
            }

            StaticDb.Movies.Add(newMovie);

            return Ok(newMovie);
        }
        [HttpGet("{id}")] //https://localhost:[port]/api/Movies/1
        public IActionResult GetMovieById([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id can not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);

                if (movieDb is null)
                {
                    return NotFound($"Movie with id: {id} does not exist");
                }

                var mapToMovieDb = movieDb.MapToMovieDTO();

                return Ok(mapToMovieDb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }
        [HttpGet("findById")] //https://localhost:[port]/api/Movies/findById?id=1
        public IActionResult GetMovieFromId([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id can not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);

                if (movieDb is null)
                {
                    return NotFound($"Movie with id: {id} does not exist");
                }

                var mapToMobieDb = movieDb.MapToMovieDTO();

                return Ok(movieDb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }
        [HttpDelete("{id}")] //https://localhost:[port]/api/movies/1
        public IActionResult DeleteById([FromRoute] int id) 
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id can not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);

                if (movieDb is null)
                {
                    return NotFound($"Movie with id {id} was not found!");
                }

                StaticDb.Movies.Remove(movieDb);
                return Ok("Movie deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        } 
        [HttpPut("{id}")] //https://localhost:[port]/api/Movies/1
        public IActionResult UpdateMovie([FromRoute] int id, [FromBody] Movie updatedMovie) 
        {
            // Validate the updatedMovie object

            var existingMovie = StaticDb.Movies.FirstOrDefault(movie => movie.Id == id);

            if (existingMovie == null)
            {
                return NotFound($"Movie with id: {id} does not exist");
            }

            existingMovie.title = updatedMovie.title;
            existingMovie.genre = updatedMovie.genre;
            existingMovie.year = updatedMovie.year;
            existingMovie.description = updatedMovie.description;

            return Ok(existingMovie);
        }
        [HttpPost("titles")] //https://localhost:[port]/api/Movies/titles
        public IActionResult GetTitlesFromMovies([FromBody] List<Movie> movies)
        {
            if (movies == null || movies.Count == 0)
            {
                return BadRequest("Invalid movie data!");
            }

            List<string> titles = movies.Select(movie => movie.title).ToList();
            return Ok(titles);
        }
        [HttpGet("filter")] //https://localhost:[port]/api/Movies/filter
        public IActionResult GetMoviesByGenreAndYear([FromQuery] Genre? genre, [FromQuery] int? year)
        {
            var filteredMovies = StaticDb.Movies;

            if (genre != null)
            {
                filteredMovies = filteredMovies.Where(m => m.genre == genre).ToList();
            }

            if (year != null)
            {
                filteredMovies = filteredMovies.Where(m => m.year == year).ToList();
            }

            return Ok(filteredMovies);
        }
    }
}
