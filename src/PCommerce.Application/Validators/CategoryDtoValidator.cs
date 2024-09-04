using FluentValidation;
using PCommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Validators
{
    public class CategoryDtoValidator:AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(CategoryDto => CategoryDto.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
