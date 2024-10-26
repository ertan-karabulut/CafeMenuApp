using AutoMapper;
using CafeMenuApp.Application.DTO.Property;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Mapper;

public class PropertyMapping : Profile
{
    public PropertyMapping()
    {
        CreateMap<Property, DetailPropertyDto>().ReverseMap();
        CreateMap<Property, ListPropertyResponseDto>();
        CreateMap<Property, CreatePropertyResponseDto>();
    }
}
