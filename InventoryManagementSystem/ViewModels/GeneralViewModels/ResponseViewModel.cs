namespace InventoryManagementSystem.ViewModels.GeneralViewModels
{
    public class ResponseViewModel<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NoError;

        public static ResponseViewModel<T> SuccessfulResponse(T? data, string message = "")
        {
            return new ResponseViewModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                ErrorCode = ErrorCode.NoError
            };
        }

        public static ResponseViewModel<T> UnsuccessfulResponse(ErrorCode errorCode, string message = "")
        {
            return new ResponseViewModel<T>
            {
                Data = default,
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode,
            };
        }
    }
}
