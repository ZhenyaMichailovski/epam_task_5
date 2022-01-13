using epam_task_5.BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.BusinessLogic.Interfaces
{
    public interface ILibraryService
    {
        int CreateBook(BookDto item);
        BookDto GetBookById(int id);
        IList<BookDto> GetAllBooks();
        void DeleteBook(int id);
        void UpdateBook(BookDto item);

        int CreateClient(ClientDto item);
        ClientDto GetClientById(int id);
        IList<ClientDto> GetAllClients();
        void DeleteClient(int id);
        void UpdateClient(ClientDto item);

        int CreateOrder(OrderDto item);
        OrderDto GetOrderById(int id);
        IList<OrderDto> GetAllOrders();
        void DeleteOrder(int id);
        void UpdateOrder(OrderDto item);
    }
}
