namespace Global.Shared.Entities;

public class FailFirst
{
    protected FailFirst()
    {
        ErrorsList = new List<Error>();
    }

    public bool IsValid { get; private set; } = true;
    public List<Error> ErrorsList { get; }

    public void IsNotNull(string attr, string attrName, string message)
    {
        if (string.IsNullOrEmpty(attr))
        {
            IsValid = false;
            ErrorsList.Add(new Error(attrName, message));
        }
    }
}