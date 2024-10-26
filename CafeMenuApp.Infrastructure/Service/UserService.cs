using AutoMapper;
using CafeMenuApp.Application.DTO.Category;
using CafeMenuApp.Application.DTO.User;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Application.Interface.Persistence.UoW;
using CafeMenuApp.Infrastructure.Validator;
using System.Text;
using System.Security.Cryptography;
using CafeMenuApp.Domain.Entities;

namespace CafeMenuApp.Infrastructure.Service;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserValidator _userValidator;

    public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userValidator = userValidator;
    }
    public async Task CreateAsync(CreateUserRequestDto request, CancellationToken cancellationToken = default)
    {
        await _userValidator.ValidateUserCreateAsync(request, cancellationToken);
        var user = request.CreteUser();
        GenerateHash(user, request.Password);
        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(DetailUserDto user, CancellationToken cancellationToken = default)
    {
        var updateUser = await _userRepository.GetByIdAsync(user.Id, cancellationToken) ?? throw new Exception("Kullanıcı bulunamadı.");
        updateUser.Name = user.Name;
        updateUser.SurName = user.SurName;
        updateUser.UserName = user.UserName;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ListUserResponseDto>> ListAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<ListUserResponseDto>>(users);
    }
    public async Task<DetailUserDto> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Kullanıcı bulunamadı.");
        return _mapper.Map<DetailUserDto>(user);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken) ?? throw new Exception("Kullanıcı bulunamadı.");
        user.IsDeleted = true;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Login(string userName, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByUserNameAsync(userName, cancellationToken);
        if(user == null) return false;
        return VerifyPassword(user.SaltPassword, user.HasPassword, password);
    }

    private void GenerateHash(User user, string password)
    {
        using (var sha256 = SHA256.Create())
        {
            string saltPassword = Guid.NewGuid().ToString();
            var combinedPasswordSalt = $"{password}{saltPassword}";
            byte[] bytes = Encoding.UTF8.GetBytes(combinedPasswordSalt);

            byte[] hash = sha256.ComputeHash(bytes);
            user.SaltPassword = saltPassword;
            user.HasPassword = Convert.ToBase64String(hash);
        }
    }

    private bool VerifyPassword(string saltPassword, string hasPassword, string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var combinedPasswordSalt = $"{password}{saltPassword}";
            byte[] bytes = Encoding.UTF8.GetBytes(combinedPasswordSalt);

            byte[] hash = sha256.ComputeHash(bytes);
            var createHash = Convert.ToBase64String(hash);
            return createHash == hasPassword;
        }
    }
}
