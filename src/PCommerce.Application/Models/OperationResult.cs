

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
    public class OperationResult<T> : OperationResult
    {
        public T ResultValue { get; }

        public OperationResult(bool isSuccess, string errorMessage, T resultValue): base(isSuccess, errorMessage)
        {
            ResultValue = resultValue;
        }
        public static OperationResult<T> Success(T resultValue)
        {
            return new OperationResult<T>(true, string.Empty, default);
        }
        public static OperationResult<T> Failure(string message)
        {
            return new OperationResult<T>(false, message, default);
        }
    }

}
