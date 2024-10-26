using CafeMenuApp.Application.DTO.User;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.Property;

public class UpdateUserValidation : AbstractValidator<DetailUserDto>
{
    public UpdateUserValidation()
    {
        RuleFor(x=> x.Name).NotEmpty().MaximumLength(30);
        RuleFor(x=>x.SurName).NotEmpty().MaximumLength(50);
    }
}
