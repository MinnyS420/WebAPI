using MoviesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Domain
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [Required]
        [Range(1900, 2100)] // Example range for the year
        public int Year { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
