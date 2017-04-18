using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Example
    {
        static List<Customer> customers = new List<Customer>
        {
            new Customer{first = "Marge", last = "Smith", state = "IL", bookGenre = "Thriller"},
            new Customer{first = "John", last = "Doe", state = "GA", bookGenre = "Comedy"},
            new Customer{first = "Peter", last = "Johnson", state = "IL", bookGenre = "Thriller"},
            new Customer{first = "Jerry", last = "Springer", state = "CA", bookGenre = "Horror"},
            new Customer{first = "Sydney", last = "Williams", state = "AR", bookGenre = "Adventure"},
            new Customer{first = "Grant", last = "Cooper", state = "FL", bookGenre = "Horror"},
            new Customer{first = "Lydia", last = "Ames", state = "CA", bookGenre = "Comedy" }
        };

        static List<Books> books = new List<Books>
        {
            new Books{book = "Bossypants", author = "Tina Fey", genre = "Comedy", releaseYear = 2011},
            new Books{book = "Three Men in a Boat", author = "Jerome K. Jerome", genre = "Comedy", releaseYear = 1889},
            new Books{book = "Dracula", author = "Bram Stoker", genre = "Horror", releaseYear = 1897 },
            new Books{book = "The Hobbit", author = "J. R. R. Tolkien", genre = "Adventure", releaseYear = 1937},
            new Books{book = "The Silence of the Lambs", author = "Thomas Harris", genre = "Thriller", releaseYear = 1988},
            new Books{book = "The Call of the Wild", author = "Jack London", genre = "Adventure", releaseYear = 1903},
            new Books{book = "The Lightning Thief", author = "Rick Riordan", genre = "Adventure", releaseYear = 2005},
            new Books{book = "The Shining", author = "Stephen King", genre = "Horror", releaseYear = 1977}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("ACME Book Database");
            Console.WriteLine("Which books are recommended for each customer?\n");

            var bookQuery = customers
                .GroupJoin(books, b => b.bookGenre, c => c.genre,
                (c, b) => new { custData = c.first + " " + c.last + " (" + c.bookGenre + ")", bookData = b.Select(books => books.book +
                ", by " + books.author + " (" + books.releaseYear.ToString() + ")") });
            foreach (var foundData in bookQuery)
            {
                Console.WriteLine("{0}", foundData.custData);
                foreach (var chosenBook in foundData.bookData)
                {
                    Console.WriteLine("{0}", chosenBook);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
