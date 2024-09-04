﻿using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct.Validation;


namespace PCommerce.Application.Services
{
    public class ValidationService
    {
        private readonly IServiceProvider _serviceProvider;   
        public ValidationService (IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task ValidateAsync<T>(T enter)
        {
           var validator = _serviceProvider.GetService<IValidator<T>>();
            if (validator == null)
            {
                throw new Exception();
            }
            await validator.ValidateAndThrowAsync(enter);
        }
        
    }
}
