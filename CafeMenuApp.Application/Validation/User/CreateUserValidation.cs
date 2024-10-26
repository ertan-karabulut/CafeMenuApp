using CafeMenuApp.Application.DTO.User;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.User;
public class CreateUserValidation : AbstractValidator<CreateUserRequestDto>
{
    public CreateUserValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x => x.SurName).NotEmpty().MaximumLength(50);
        RuleFor(x=>x.Password).NotEmpty().MaximumLength(10);
    }
}
