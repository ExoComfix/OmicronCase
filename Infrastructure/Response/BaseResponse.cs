public class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public BaseResponse(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public BaseResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
