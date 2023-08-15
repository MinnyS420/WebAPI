using MoviesApp.Models;

namespace MoviesApp
{
    public static class StaticDb
    {
        public static int MovieId = 3;
        public static List<Movie> Movies = new List<Movie>() 
        {
           new Movie
           {
               Id = 1,
               title = "Foo",
               description = "Bar",
               genre = Models.Enums.Genre.Action,
               year = 2014,
           },
           new Movie
           {
               Id = 2,
               title = "Boo",
               description = "Bar",
               genre = Models.Enums.Genre.Thriller,
               year = 2015,
           },
           new Movie
           {
               Id = 3,
               title = "Hoo",
               description = "Bar",
               genre = Models.Enums.Genre.Comedy,
               year = 2016,
           }

        };
    }
}
