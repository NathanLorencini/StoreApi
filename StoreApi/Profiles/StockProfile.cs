using AutoMapper;
using StoreApi.Data.Dtos;
using StoreApi.Models;

namespace StoreApi.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, ReadStockDto>()
                .ForMember(x => x.ReadProdcutDto,
                    opts =>
                    opts.MapFrom(y => y.Product)).ReverseMap();

            CreateMap<Stock, UpdateStockDto>().ReverseMap();
        }
    }
}
