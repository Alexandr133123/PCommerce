

using FluentValidation;
using PCommerce.Application.Models;

namespace PCommerce.Application.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
        }
    }
}
