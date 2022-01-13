using AutoMapper;
using epam_task_5.BusinessLogic.Dtos;
using epam_task_5.BusinessLogic.Interfaces;
using epam_task_5.DataAccess.Entities;
using epam_task_5.DataAccess.Interfaces;
using epam_task_5.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.BusinessLogic.Services
{
    /// <summary>
    /// Servic to work with library
    /// </summary>
    public class LibraryService : ILibraryService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Order> _orderRepository;

        private readonly IMapper _mapper;

        public LibraryService(IMapper mapper, IRepository<Book> bookRepository, IRepository<Client> clientRepository, IRepository<Order> orderRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
        }

        public int CreateBook(BookDto item)
        {
            return _bookRepository.Create(_mapper.Map<Book>(item));
        }
        public BookDto GetBookById(int id)
        {
            return _mapper.Map<BookDto>(_bookRepository.GetById(id));
        }
        public IList<BookDto> GetAllBooks()
        {
            return _mapper.Map<IEnumerable<BookDto>>(_bookRepository.GetAll()).ToList();
        }
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
        public void UpdateBook(BookDto item)
        {
            _bookRepository.Update(_mapper.Map<Book>(item));
        }


        public int CreateOrder(OrderDto item)
        {
            return _orderRepository.Create(_mapper.Map<Order>(item));
        }
        public OrderDto GetOrderById(int id)
        {
            return _mapper.Map<OrderDto>(_orderRepository.GetById(id));
        }
        public IList<OrderDto> GetAllOrders()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(_orderRepository.GetAll()).ToList();
        }
        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }
        public void UpdateOrder(OrderDto item)
        {
            _orderRepository.Update(_mapper.Map<Order>(item));
        }


        public int CreateClient(ClientDto item)
        {
            return _clientRepository.Create(_mapper.Map<Client>(item));
        }
        public ClientDto GetClientById(int id)
        {
            return _mapper.Map<ClientDto>(_clientRepository.GetById(id));
        }
        public IList<ClientDto> GetAllClients()
        {
            return _mapper.Map<IEnumerable<ClientDto>>(_clientRepository.GetAll()).ToList();
        }
        public void DeleteClient(int id)
        {
            _clientRepository.Delete(id);
        }
        public void UpdateClient(ClientDto item)
        {
            _clientRepository.Update(_mapper.Map<Client>(item));
        }

        /// <summary>
        /// method to find the most popular author
        /// </summary>
        /// <returns>Author</returns>
        public string FindMostPopularAuthor()
        {
            var books = _mapper.Map<IEnumerable<BookDto>>(_bookRepository.GetAll().ToList());
            var orders = _mapper.Map<IEnumerable<OrderDto>> (_orderRepository.GetAll().ToList());

            var authors = from o in books
                             join t in orders on o.Id equals t.IdBook
                             select new { Author = o.Author };


            var needAuthor = authors.GroupBy(p => p.Author)
                .Select(g => new { Author = g.Key, Count = g.Count() });

            return needAuthor.FirstOrDefault(x => x.Count == needAuthor.Max(y => y.Count)).Author;
        }

        /// <summary>
        /// Method to find the most reading subscriber  
        /// </summary>
        /// <returns>FIO by client</returns>
        public string FindMostReadingSubscriber()
        {
            var client = _mapper.Map<IEnumerable<ClientDto>>(_clientRepository.GetAll().ToList());
            var orders = _mapper.Map<IEnumerable<OrderDto>>(_orderRepository.GetAll().ToList());

            var clients = from o in client
                          join t in orders on o.Id equals t.IdClient
                          select new { FIO = o.FIO, Sex = o.Sex };

            var needClient = clients.GroupBy(p => p.FIO)
                .Select(g => new { FIO = g.Key, Count = g.Count() });

            return needClient.FirstOrDefault(x => x.Count == needClient.Max(y => y.Count)).FIO;
        }

        /// <summary>
        /// Mathod to find the most popular genre
        /// </summary>
        /// <returns>genre</returns>
        public string FindMostPopularGenre()
        {
            var book = _mapper.Map<IEnumerable<BookDto>>(_bookRepository.GetAll().ToList());
            var orders = _mapper.Map<IEnumerable<OrderDto>>(_orderRepository.GetAll().ToList());

            var books = from o in book
                          join t in orders on o.Id equals t.IdBook
                          select new { Name = o.Name };

            var needBooks = books.GroupBy(p => p.Name)
                .Select(g => new { Name = g.Key, Count = g.Count() });

            return needBooks.FirstOrDefault(x => x.Count == needBooks.Max(y => y.Count)).Name;
        }
    }
}
