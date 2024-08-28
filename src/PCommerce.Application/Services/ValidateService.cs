using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Services
{
    public class ValidateService:IValidatorService
    {
        public readonly IServiceProvider _serviceProvider;

        public ValidateService(IServiceProvider serviceProvider)
        {

         _serviceProvider = serviceProvider;  

        }

        public async Task ValidateAsync<T>(T entry)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new Exception();
            }

            await validator.ValidateAndThrowAsync(entry);
        }

    }
}
