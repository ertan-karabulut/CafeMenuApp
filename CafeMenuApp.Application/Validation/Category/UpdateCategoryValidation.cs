using CafeMenuApp.Application.DTO.Category;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.Category;
public class UpdateCategoryValidation : AbstractValidator<DetailCategoryDto>
{
    public UpdateCategoryValidation()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}
