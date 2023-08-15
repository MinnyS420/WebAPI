using MoviesApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Models
{
    public class Movie : BaseEntity
    {
        [Required]
        public string title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public Genre genre { get; set; }

        [Required]
        [Range(1900, 2100)] // Example range for the year
        public int year { get; set; }

        [MaxLength(250)]
        public string description { get; set; }
    }
}
