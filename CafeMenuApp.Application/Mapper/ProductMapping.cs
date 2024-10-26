using AutoMapper;
using CafeMenuApp.Application.DTO.Product;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Mapper;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, CreateProductResponseDto>();
        CreateMap<Product, ListProductResponseDto>().ForMember(x=>x.CategoryName, x=> x.MapFrom(y=>y.Category.Name));
        CreateMap<Product, DetailProductDto>().ForMember(x => x.CategoryName, x => x.MapFrom(y => y.Category.Name));
    }
}
