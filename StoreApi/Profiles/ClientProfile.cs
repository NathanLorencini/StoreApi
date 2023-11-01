using AutoMapper;
using StoreApi.Data.Dtos;
using StoreApi.Models;

namespace StoreApi.Profiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ReadClientDto>().ReverseMap();
        
        CreateMap<Client, CreateClientDto>().ReverseMap();

    }
}