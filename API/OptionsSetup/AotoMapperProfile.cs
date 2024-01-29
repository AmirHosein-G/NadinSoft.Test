using AutoMapper;
using Domain.Dto.ProductDtos;
using Domain.Entiys;

namespace API.OptionsSetup;

public class AotoMapperProfile: Profile
{
    public AotoMapperProfile()
    {
        CreateMap<Product, ProductDto> ();
    }
}