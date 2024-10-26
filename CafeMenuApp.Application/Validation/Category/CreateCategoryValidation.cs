using CafeMenuApp.Application.DTO.Category;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.Category;
public class CreateCategoryValidation : AbstractValidator<CreateCategoryRequestDto>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
