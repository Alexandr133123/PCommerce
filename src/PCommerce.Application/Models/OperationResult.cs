using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Models
{
    public class OperationResult
    {
        readonly bool IsSuccess;
        
        readonly string ErrorMessage;

        protected OperationResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;

            ErrorMessage = errorMessage;
        }

        public bool IsFaulted => !IsSuccess;

        public static OperationResult Success()
        {
            return new OperationResult(true,string.Empty);
        }

        public static OperationResult Failure(string errorMessage)
        {
            return new OperationResult(false,errorMessage);
        }
    }
}
