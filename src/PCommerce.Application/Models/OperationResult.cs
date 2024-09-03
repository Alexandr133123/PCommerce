

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
    public class OperationRusult<T> : OperationResult
    {
        public T ResultValue { get; }

        public OperationRusult(bool isSuccess, string errorMessage, T resultValue): base(isSuccess, errorMessage)
        {
            ResultValue = resultValue;
        }
        public static OperationRusult<T> Succecc(T resultValue)
        {
            return new OperationRusult<T>(true, string.Empty, default);
        }
        public static OperationRusult<T> Failure(string message)
        {
            return new OperationRusult<T>(false, message, default);
        }
    }

}
