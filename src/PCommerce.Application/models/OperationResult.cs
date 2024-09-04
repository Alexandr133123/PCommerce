using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.models
{
    public class OperationResult
    {
        public bool Result { get; }
        public string MessageError { get; }
        public bool IsFaulted => !Result;
        protected OperationResult(bool result, string messageError)
        {
           Result = result;
           MessageError = messageError;
        }

        public static OperationResult Success()
        {
           return new OperationResult(true, string.Empty);
        }

        public static OperationResult Failure(string message)
        {
            return new OperationResult (false, message);
        }
    }
}
