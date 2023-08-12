using Homework_2.Models;

namespace Homework2
{
    public static class StaticDb
    {
        public static List<Book> Books { get; set; } = new List<Book>
        {
            new Book
            {
                Author = "Author1",
                Title = "Book Title 1"
            },
            new Book
            {
                Author = "Author2",
                Title = "Book Title 2"
            }
        };
    }
}