
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Models;
using PCommerce.Application.Validators;


namespace PCommerce.Application.Services
{
    public class ValidationService
    {
        private readonly IServiceProvider _serviceProvider;
        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task ValidateAsync<T>(T entry)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if(validator == null)
            {
                throw new Exception();
            }

            await validator.ValidateAndThrowAsync(entry);
        }
    }
}
