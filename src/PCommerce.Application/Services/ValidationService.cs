
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Models;


namespace PCommerce.Application.Services
{
    public class ValidationService
    {
        private readonly IServiceProvider _serviceProvider;
        public ValidationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<OperationResult> ValidateAsync<T>(T entry)
        {
            var validator = _serviceProvider.GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new Exception();
            }

            var validateResult = await validator.ValidateAsync(entry);

            if (validateResult.IsValid)
            {
                return OperationResult.Success();
            }

            var errorMessage = validateResult.Errors.Select(e => e.ErrorMessage);

            var message = string.Join("\n", errorMessage);

            return OperationResult.Failure(message);

        }
    }
}
