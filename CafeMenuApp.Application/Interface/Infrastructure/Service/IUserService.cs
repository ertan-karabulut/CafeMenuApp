using CafeMenuApp.Application.DTO.User;

namespace CafeMenuApp.Application.Interface.Infrastructure.Service;

public interface IUserService
{
    Task CreateAsync(CreateUserRequestDto request, CancellationToken cancellationToken = default);
    Task UpdateAsync(DetailUserDto user, CancellationToken cancellationToken = default);
    Task<List<ListUserResponseDto>> ListAsync(CancellationToken cancellationToken = default);
    Task<DetailUserDto> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> Login(string userName, string password, CancellationToken cancellationToken = default);
}
