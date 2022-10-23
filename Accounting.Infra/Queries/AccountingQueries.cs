namespace Accounting.Infra.Queries;

public class AccountingQueries
{
    private readonly string basePath = "Assets/Queries";

    public string CreateAccountType()
    {
        return File.ReadAllText($"{basePath}/CreateAccountType.sql");
    }
}