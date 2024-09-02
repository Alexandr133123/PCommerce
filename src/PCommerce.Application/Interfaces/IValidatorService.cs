using PCommerce.Application.Models;
using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Interfaces
{
    public interface IValidatorService
    {
        Task <ValidationResult> ValidateAsync<T>(T entry); 
    }
}
