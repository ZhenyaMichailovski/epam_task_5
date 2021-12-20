using epam_task_5.DataAccess.Entities;
using epam_task_5.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;

namespace TestLibrary
{
    [TestClass]
    public class TestDataAccess
    {
        [TestMethod]
        public void TestGetAllMethod()
        {
            List<Book> books = new List<Book>()
            {
                new Book{ Id = 1, Author = "Author1", Genre = "Genre1", Name = "Book1" },
                new Book{ Id = 2, Author = "Author2", Genre = "Genre2", Name = "Book2" },
                new Book{ Id = 3, Author = "Author3", Genre = "Genre3", Name = "Book3" },
                new Book{ Id = 4, Author = "Author4", Genre = "Genre4", Name = "Book4" },
                new Book{ Id = 5, Author = "Author5", Genre = "Genre5", Name = "Book5" },
            };
            BookRepository bookRepository = new BookRepository();
            var items = bookRepository.GetAll();

            items.Should().BeEquivalentTo(books);
        }
    }
}
