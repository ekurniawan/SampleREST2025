using AutoMapper;
using CodeFirstSample.DTO;
using CodeFirstSample.Models;

namespace CodeFirstSample.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<OrderHeader, OrderHeaderDTO>();
        }
    }
}
