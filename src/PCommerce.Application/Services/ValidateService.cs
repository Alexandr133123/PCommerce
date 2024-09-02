using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace PCommerce.Application.Services
{
    public class ValidateService:IValidatorService
    {
        public readonly IServiceProvider _serviceProvider;

        public ValidateService(IServiceProvider serviceProvider)
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

            else
            {
                string responseMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(responseMessage);
            }
        }

    }
}
