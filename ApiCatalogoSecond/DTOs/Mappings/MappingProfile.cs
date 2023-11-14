using ApiCatalogoSecond.Domain.Entities;
using AutoMapper;

namespace ApiCatalogoSecond.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
