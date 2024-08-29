using PCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCommerce.Application.Services
{
    public class ValidationService
    {
        private readonly PCommerceDbContext _dbContext;
        public ValidationService(PCommerceDbContext validatorService)
        {
            _dbContext = validatorService;
        }
        public async Task ValidateAsync<T>(T entry)
        {
           
        }
    }
}
