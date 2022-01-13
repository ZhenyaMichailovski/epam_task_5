using AutoMapper;
using epam_task_5.DataAccess.Entities;
using epam_task_5.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace epam_task_5.BusinessLogic.Mapper
{
    public class BusinessLogicMapperProfile : Profile
    {
        public BusinessLogicMapperProfile()
        {

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}
