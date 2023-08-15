using MoviesApp.Models.Enums;

namespace MoviesApp.DTOs
{
    public class MovieDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public int year { get; set; }
        public Genre genre { get; set; }
    }
}
