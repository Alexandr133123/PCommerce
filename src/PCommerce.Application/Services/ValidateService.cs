using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Interfaces;
using FluentValidation.Results;

namespace PCommerce.Application.Services
{
    public class ValidateService:IValidatorService
    {
        public readonly IServiceProvider _serviceProvider;

        public ValidateService(IServiceProvider serviceProvider)
        {

         _serviceProvider = serviceProvider;  

        }

        public async Task<ValidationResult> ValidateAsync<T>(T entry)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new Exception();
            }

            return await validator.ValidateAsync(entry);

            
        }

    }
}
