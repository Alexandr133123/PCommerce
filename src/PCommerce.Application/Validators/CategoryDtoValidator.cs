

using FluentValidation;
using PCommerce.Application.Models;

namespace PCommerce.Application.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(n => n.Name).NotEmpty().NotNull();
        }
    }
}
