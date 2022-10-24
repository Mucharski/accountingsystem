namespace Global.Shared.Entities;

public class Error
{
    public Error(string attributeName, string message)
    {
        AttributeName = attributeName;
        Message = message;
    }

    public string AttributeName { get; }
    public string Message { get; }
}