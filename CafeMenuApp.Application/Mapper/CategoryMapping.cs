using AutoMapper;
using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Mapper;
public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CreateCategoryResponseDto>();
        CreateMap<Category, ListCategoryResponseDto>().ForMember(x=>x.ParentCategoryName, x=>x.MapFrom(y=>y.ParentCategory.Name));
        CreateMap<Category, DetailCategoryDto>().ForMember(x => x.ParentCategoryName, x => x.MapFrom(y => y.ParentCategory.Name));
    }
}
