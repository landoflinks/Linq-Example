using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqExampleTest
{
    [TestClass]
    public class LinqExampleTest
    {
        static List<Customer> customers = new List<Customer>
        {
            new Customer{first = "John", last = "Doe", state = "GA", bookGenre = "Comedy"}
        };

        static List<Books> books = new List<Books>
        {
            new Books{book = "Bossypants", author = "Tina Fey", genre = "Comedy", releaseYear = 2011},
        };

        [TestMethod]
        public void TestLinqExampleCustOnly()
        {
            var bookQuery = customers
                .GroupJoin(books, b => b.bookGenre, c => c.genre,
                (c, b) => new {
                    custData = c.first + " " + c.last + " (" + c.bookGenre + ")",
                    bookData = b.Select(books => books.book +
                    ", by " + books.author + " (" + books.releaseYear.ToString() + ")")
                });
            foreach (var foundData in bookQuery)
            {
                string expectedCustResponse = "John Doe (Comedy)";
                string custResponse = String.Format("{0}", foundData.custData);
                Assert.AreEqual(custResponse, expectedCustResponse);
                Console.WriteLine("{0}", foundData.custData);
            }
        }

        [TestMethod]
        public void TestLinqExampleMainProgram()
        {
            var bookQuery = customers
                .GroupJoin(books, b => b.bookGenre, c => c.genre,
                (c, b) => new {
                    custData = c.first + " " + c.last + " (" + c.bookGenre + ")",
                    bookData = b.Select(books => books.book +
                    ", by " + books.author + " (" + books.releaseYear.ToString() + ")")
                });
            foreach (var foundData in bookQuery)
            {
                string expectedCustResponse = "John Doe (Comedy)";
                string custResponse = String.Format("{0}", foundData.custData);
                Assert.AreEqual(custResponse, expectedCustResponse);
                //Console.WriteLine("{0}", foundData.custData);

                foreach (var chosenBook in foundData.bookData)
                {
                    string expectedBookResponse = "Bossypants, by Tina Fey (2011)";
                    string bookResponse = String.Format("{0}", chosenBook);
                    Assert.AreEqual(bookResponse, expectedBookResponse);
                    //Console.WriteLine("{0}", chosenBook);
                }
                Console.WriteLine();
            }
        }
    }
}
