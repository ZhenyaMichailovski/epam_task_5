using epam_task_5.DataAccess.Entities;
using epam_task_5.DataAccess.Repositories;
using epam_task_5.DataAccess.Enums;
using epam_task_5.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;
using epam_task_5.DataAccess.Interfaces;

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
                new Book{ Id = 1, Author = "Author1", Genre = "Genre1", Name = "Book1", Condition = ConditionEnum.Bad, Returned = StatusEnum.NotReturned },
                new Book{ Id = 2, Author = "Author2", Genre = "Genre2", Name = "Book2", Condition = ConditionEnum.Normal, Returned = StatusEnum.Returned },
                new Book{ Id = 3, Author = "Author3", Genre = "Genre3", Name = "Book3", Condition = ConditionEnum.Good, Returned = StatusEnum.NotReturned },
                new Book{ Id = 4, Author = "Author4", Genre = "Genre4", Name = "Book4", Condition = ConditionEnum.Bad, Returned = StatusEnum.Returned },
                new Book{ Id = 5, Author = "Author5", Genre = "Genre5", Name = "Book5", Condition = ConditionEnum.Normal, Returned = StatusEnum.NotReturned },
            };
            BookRepository bookRepository = new BookRepository(Connection.ConnectionString);
            var items = bookRepository.GetAll();

            items.Should().BeEquivalentTo(books);
        }

        [TestMethod]
        public void TestGetById()
        {
            Book book = new Book()
            {
                Id = 1,
                Author = "Author1",
                Genre = "Genre1",
                Name = "Book1",
                Condition = ConditionEnum.Bad,
                Returned = StatusEnum.NotReturned
            };

            BookRepository bookRepository = new BookRepository(Connection.ConnectionString);
            var items = bookRepository.GetById(1);

            items.Should().BeEquivalentTo(book);
        }
        
        
    }
}
