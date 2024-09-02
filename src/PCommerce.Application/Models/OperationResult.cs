using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Models
{
    public class OperationResult
    {
        public  bool IsSuccess { get; }
        
        public string ErrorMessage { get; }

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
