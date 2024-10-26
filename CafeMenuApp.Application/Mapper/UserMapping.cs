using AutoMapper;
using CafeMenuApp.Application.DTO.User;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Application.Mapper;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, DetailUserDto>();
        CreateMap<User, ListUserResponseDto>();
    }
}
