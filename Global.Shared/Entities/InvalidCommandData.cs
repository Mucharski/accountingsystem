namespace Global.Shared.Entities;

public class InvalidCommandData : IGenericApiResponse
{
    public InvalidCommandData(IReadOnlyCollection<Error> errors)
    {
        Errors = errors;
        Success = false;
        Message = "Foram enviados dados incorretos.";
    }

    public IReadOnlyCollection<Error> Errors { get; }
    public bool Success { get; }
    public string Message { get; }
}