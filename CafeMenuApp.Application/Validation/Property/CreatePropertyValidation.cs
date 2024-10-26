using CafeMenuApp.Application.DTO.Property;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.Property;
public class CreatePropertyValidation : AbstractValidator<CreatePropertyRequestDto>
{
    public CreatePropertyValidation()
    {
        RuleFor(x => x.Key).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Value).NotEmpty().MaximumLength(50);
    }
}
