using CafeMenuApp.Application.DTO.User;
using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Infrastructure.Validator;

public interface IUserValidator
{
    Task ValidateUserCreateAsync(CreateUserRequestDto product, CancellationToken cancellationToken = default);
}
public class UserValidator : IUserValidator
{
    private readonly IUserRepository _userRepository;
    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task ValidateUserCreateAsync(CreateUserRequestDto user, CancellationToken cancellationToken = default)
    {
        await IfValidateUserAsync(user.UserName, cancellationToken);
    }

    public async Task IfValidateUserAsync(string userName, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByUserNameAsync(userName, cancellationToken);
        if (user != null)
            throw new Exception("UserName kullanılmakta.");
    }
}
