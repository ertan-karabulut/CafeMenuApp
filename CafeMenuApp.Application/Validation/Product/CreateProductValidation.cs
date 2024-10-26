using CafeMenuApp.Application.DTO.Product;
using FluentValidation;

namespace CafeMenuApp.Application.Validation.Product;

public class CreateProductValidation : AbstractValidator<CreateProductRequestDto>
{
    public CreateProductValidation()
    {
        RuleFor(x=> x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x=>x.ImagePath).MaximumLength(500);
    }
}
