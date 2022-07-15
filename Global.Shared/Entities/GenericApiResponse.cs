namespace Global.Shared.Entities;

public class GenericApiResponse<T>
{
    public GenericApiResponse(T data, bool success, string message)
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public T Data { get; }
    public bool Success { get; }
    public string Message { get; }
}