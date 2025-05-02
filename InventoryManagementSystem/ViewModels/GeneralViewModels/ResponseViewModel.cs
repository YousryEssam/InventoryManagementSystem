namespace InventoryManagementSystem.ViewModels.GeneralViewModels
{
    public class ResponseViewModel <T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NoError;


        public static ResponseViewModel<T> Success(T? data , string message = "")
        {
            return new SuccessResponseViewModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                ErrorCode = ErrorCode.NoError
            };
        }

        public static ErrorResponseViewModel Error(ErrorCode errorCode, string message = "")
        {
            return new ErrorResponseViewModel
            {
                Data = default,
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode,
            };
        }

    }
}
