

namespace PCommerce.Application.Models
{
    public class OperationResult
    {
        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public bool IsFaulted => !IsSuccess;

        protected OperationResult(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
        public static OperationResult Success()
        {
            return new OperationResult(true, null);
        }
        public static OperationResult Failure(string message)
        {
            return new OperationResult(false, message);
        }
    }
}
