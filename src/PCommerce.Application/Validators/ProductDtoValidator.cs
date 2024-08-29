using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PCommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator() 
        { 
           RuleFor (product => product.Name).NotNull().NotEmpty();
        }
    }
}
