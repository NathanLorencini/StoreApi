using AutoMapper;
using StoreApi.Data.Dtos;
using StoreApi.Models;

namespace StoreApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
        }

    }
}
